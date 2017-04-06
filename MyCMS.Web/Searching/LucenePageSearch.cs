using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using MyCMS.Model.LuceneModel;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Search.Similar;
using Lucene.Net.Store;
using SpellChecker.Net.Search.Spell;
using Directory = System.IO.Directory;
using Version = Lucene.Net.Util.Version;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities;

namespace MyCMS.Web.Searching
{
    public class LucenePageSearch
    {
        private const Version _version = Version.LUCENE_30;

        private static readonly string _luceneDir =
            HttpContext.Current.Server.MapPath("~/App_Data/Lucene_Index");

        private static FSDirectory _directoryTemp;

        private static FSDirectory _directory
        {
            get
            {
                if (_directoryTemp == null)
                    _directoryTemp = FSDirectory.Open(new DirectoryInfo(_luceneDir));
                if (IndexWriter.IsLocked(_directoryTemp))
                    IndexWriter.Unlock(_directoryTemp);
                string lockFilePath = Path.Combine(_luceneDir, "write.lock");
                if (File.Exists(lockFilePath))
                    File.Delete(lockFilePath);
                return _directoryTemp;
            }
        }

        private readonly IPageService _pageService;
        public LucenePageSearch(IPageService pageService)
        {
            _pageService = pageService;
            if(MvcApplication.ReindexingPages == true)
            {
                Reindexing();
                MvcApplication.ReindexingPages = false;
            }
        }
        public void Reindexing()
        {
            var model = _pageService.GetAll();
            foreach (var currentPage in model)
            {
                LucenePageSearch.ClearLuceneIndexRecord(currentPage.Id);
                LucenePageSearch.AddUpdateLuceneIndex(new LucenePageModel
                {
                    SubTitle = currentPage.SubTitle,
                    Body = HtmlUtility.RemoveHtmlTags(currentPage.Body),
                    Description = currentPage.Description,
                    Keywords = currentPage.Keyword,
                    PageId = currentPage.Id,
                    Title = currentPage.Title
                });
            }
        }
        private static void _addToLuceneIndex(LucenePageModel PageData, IndexWriter writer)
        {
            // remove older index entry
            var searchQuery = new TermQuery(new Term("PageId", PageData.PageId.ToString(CultureInfo.InvariantCulture)));
            writer.DeleteDocuments(searchQuery);

            // add new index entry
            var PageDocument = new Document();

            // add lucene fields mapped to db fields
            PageDocument.Add(new Field("PageId",
                PageData.PageId.ToString(CultureInfo.InvariantCulture), Field.Store.YES, Field.Index.NOT_ANALYZED));
            
            if (PageData.Title != null)
            {
                PageDocument.Add(new Field("Title", PageData.Title, Field.Store.YES, Field.Index.ANALYZED,
                    Field.TermVector.WITH_POSITIONS_OFFSETS));
            }
            if (PageData.Body != null)
            {
                PageDocument.Add(new Field("Body", PageData.Body, Field.Store.YES, Field.Index.ANALYZED,
                    Field.TermVector.WITH_POSITIONS_OFFSETS) { Boost = 3 });
            }
            if (PageData.Keywords != null)
            {
                PageDocument.Add(new Field("Keywords", PageData.Keywords, Field.Store.YES, Field.Index.ANALYZED,
                    Field.TermVector.WITH_POSITIONS_OFFSETS));
            }
            if (PageData.SubTitle != null)
            {
                PageDocument.Add(new Field("SubTitle", PageData.SubTitle, Field.Store.YES, Field.Index.ANALYZED,
                    Field.TermVector.WITH_POSITIONS_OFFSETS));
            }
            if (PageData.Description != null)
            {
                PageDocument.Add(new Field("Description", PageData.Description, Field.Store.YES, Field.Index.ANALYZED,
                    Field.TermVector.WITH_POSITIONS_OFFSETS));
            }

            // add entry to index
            writer.AddDocument(PageDocument);
        }

        public static void AddUpdateLuceneIndex(IEnumerable<LucenePageModel> PageData)
        {
            // init lucene
            var analyzer = new StandardAnalyzer(_version);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // add data to lucene search index (replaces older entry if any)
                foreach (LucenePageModel data in PageData)
                    _addToLuceneIndex(data, writer);

                // close handles
                analyzer.Close();
                writer.Optimize();
                writer.Commit();
                writer.Dispose();
            }
        }

        public static void AddUpdateLuceneIndex(LucenePageModel PageData)
        {
            AddUpdateLuceneIndex(new List<LucenePageModel> { PageData });
        }

        public static void ClearLuceneIndexRecord(int recordId)
        {
            // init lucene
            var analyzer = new StandardAnalyzer(_version);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                // remove older index entry
                var searchQuery = new TermQuery(new Term("PageId", recordId.ToString(CultureInfo.InvariantCulture)));
                writer.DeleteDocuments(searchQuery);

                // close handles
                analyzer.Close();
                writer.Dispose();
            }
        }

        public static bool ClearLuceneIndex()
        {
            try
            {
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);
                using (var writer = new IndexWriter(_directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
                {
                    // remove older index entries
                    writer.DeleteAll();

                    // close handles
                    analyzer.Close();
                    writer.Dispose();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void Optimize()
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);
            using (var writer = new IndexWriter(_directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
                writer.Dispose();
            }
        }

        private static LucenePageModel _mapLuceneDocumentToData(Document doc)
        {
            return new LucenePageModel
            {
                PageId = Convert.ToInt32(doc.Get("PageId")),
                Body = doc.Get("Body"),
                SubTitle = doc.Get("SubTitle"),
                Keywords = doc.Get("Keywords"),
                Description = doc.Get("Description"),
                Title = doc.Get("Title")
            };
        }

        private static IEnumerable<LucenePageModel> _mapLuceneToDataList(IEnumerable<Document> hits)
        {
            return hits.Select(_mapLuceneDocumentToData).ToList();
        }

        private static IEnumerable<LucenePageModel> _mapLuceneToDataList(IEnumerable<ScoreDoc> hits,
            IndexSearcher searcher)
        {
            return hits.Select(hit => _mapLuceneDocumentToData(searcher.Doc(hit.Doc))).ToList();
        }

        private static Query parseQuery(string searchQuery, QueryParser parser)
        {
            Query query;
            try
            {
                query = parser.Parse(searchQuery.Trim());
            }
            catch (ParseException)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery.Trim()));
            }
            return query;
        }

        private static IEnumerable<LucenePageModel> _search(string searchQuery, string[] searchFields)
        {
            // validation
            if (string.IsNullOrEmpty(searchQuery.Replace("*", "").Replace("?", "")))
                return new List<LucenePageModel>();

            // set up lucene searcher
            using (var searcher = new IndexSearcher(_directory, false))
            {
                const int hitsLimit = 1000;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);


                var parser = new MultiFieldQueryParser
                    (Version.LUCENE_30, searchFields, analyzer);
                Query query = parseQuery(searchQuery, parser);
                ScoreDoc[] hits = searcher.Search(query, null, hitsLimit, Sort.RELEVANCE).ScoreDocs;

                if (hits.Length == 0)
                {
                    searchQuery = searchByPartialWords(searchQuery);
                    query = parseQuery(searchQuery, parser);
                    hits = searcher.Search(query, hitsLimit).ScoreDocs;
                }

                IEnumerable<LucenePageModel> results = _mapLuceneToDataList(hits, searcher);
                analyzer.Close();
                searcher.Dispose();
                return results;
            }
        }

        public static IEnumerable<LucenePageModel> Search(string input, params string[] fieldsName)
        {
            if (string.IsNullOrEmpty(input))
                return new List<LucenePageModel>();

            IEnumerable<string> terms = input.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Trim() + "*");
            input = string.Join(" ", terms);
            return _search(input, fieldsName);
        }

        public static IEnumerable<LucenePageModel> SearchDefault(string input, string[] fieldsName)
        {
            return string.IsNullOrEmpty(input) ? new List<LucenePageModel>() : _search(input, fieldsName);
        }

        public static IEnumerable<LucenePageModel> GetAllIndexRecords()
        {
            // validate search index
            if (!Directory.EnumerateFiles(_luceneDir).Any())
                return new List<LucenePageModel>();

            // set up lucene searcher
            var searcher = new IndexSearcher(_directory, false);
            IndexReader reader = IndexReader.Open(_directory, false);
            var docs = new List<Document>();
            TermDocs term = reader.TermDocs();
            while (term.Next()) docs.Add(searcher.Doc(term.Doc));
            reader.Dispose();
            searcher.Dispose();
            return _mapLuceneToDataList(docs);
        }

        private static string searchByPartialWords(string bodyTerm)
        {
            bodyTerm = bodyTerm.Replace("*", "").Replace("?", "");
            IEnumerable<string> terms = bodyTerm.Trim().Replace("-", " ").Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Trim() + "*");
            bodyTerm = string.Join(" ", terms);
            return bodyTerm;
        }

        public static string[] SuggestSilmilarWords(string term, int count = 10)
        {
            IndexReader indexReader = IndexReader.Open(FSDirectory.Open(_luceneDir), true);

            // Create the SpellChecker
            var spellChecker = new SpellChecker.Net.Search.Spell.SpellChecker(FSDirectory.Open(_luceneDir + "\\Spell"));

            // Create SpellChecker Index
            spellChecker.ClearIndex();
            spellChecker.IndexDictionary(new LuceneDictionary(indexReader, "Title"));
            spellChecker.IndexDictionary(new LuceneDictionary(indexReader, "Body"));
            spellChecker.IndexDictionary(new LuceneDictionary(indexReader, "SubTitle"));
            spellChecker.IndexDictionary(new LuceneDictionary(indexReader, "Keywords"));
            spellChecker.IndexDictionary(new LuceneDictionary(indexReader, "Description"));

            //Suggest Similar Words
            return spellChecker.SuggestSimilar(term, count, null, null, true);
        }

        private static int GetLuceneDocumentNumber(int PageId)
        {
            var analyzer = new StandardAnalyzer(_version);
            var parser = new QueryParser(_version, "PageId", analyzer);
            Query query = parser.Parse(PageId.ToString(CultureInfo.InvariantCulture));
            using (var searcher = new IndexSearcher(_directory, false))
            {
                TopDocs doc = searcher.Search(query, 1);

                return doc.TotalHits == 0 ? 0 : doc.ScoreDocs[0].Doc;
            }
        }
        
    }
}