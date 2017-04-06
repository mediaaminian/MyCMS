using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ninject.Infrastructure.Language;
using Raven.Abstractions.Data;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Extensions;
using System.IO;

//using Raven.Client.Embedded;

namespace ERP.Common.RavanDB
{
    public class RavenDB : IDisposable
    {

        private readonly string serverName;
        private readonly string databaseName;

        private DocumentStore documentStore;
        private IDocumentSession session;

        public RavenDB(string db)
        {
            try
            {
                RavenDbManagement m = new RavenDbManagement();
                m.CreateDb(db);
            }
            catch 
            {
            }
            

            documentStore = new DocumentStore { Url = "http://192.168.0.40:8081/" };
            documentStore.Initialize();
            session = documentStore.OpenSession(db);
        }


        //public static IDocumentStore _store;
        //public static IDocumentStore Store
        //{
        //    get
        //    {
        //        if (_store == null)
        //            Initialize();

        //        return _store;
        //    }
        //}

        //public IDocumentSession DocumentSession { get; set; }

        //public static IDocumentStore Initialize()
        //{
        //    /*_store = new EmbeddableDocumentStore { ConnectionStringName = "RavenDB" };
        //    _store.Conventions.IdentityPartsSeparator = "-";
        //    _store.Initialize();
        //    IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), Store);
        //    */



        //    _store = new DocumentStore { Url = "http://192.168.0.40/8081" };
        //    _store.Initialize();
        //    return _store;

        //}

        //public RavenDB()
        //{
        //    DocumentSession = Store.OpenSession();
        //}

        public IList<T> GetAllAsList<T>()
        {
            var contents = session.Query<T>().ToList();
            return contents;
        }

        public IEnumerable<T> GetAllAsEnumerable<T>()
        {
            return session.Query<T>().ToEnumerable();
        }

        public T GetById<T>(string Id)
        {
            return session.Load<T>(Id);
        }
        public T Get<T>(Expression<Func<T, bool>> predicate)
        {
            return session.Query<T>().Where(predicate.Compile()).FirstOrDefault(); 
            
        }

        public void Add<T>(T t)
        {
            session.Store(t);
        }

        public void Delete<T>(T t)
        {
            session.Delete(t);
        }

        public void SaveChanges()
        {
            session.SaveChanges();
        }

        public bool Log<T>(T t)
        {
            session.Store(t);
            session.SaveChanges();
            return true;
        }
        bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }
    }


public class RavenDbManagement: IDisposable
{
        private DocumentStore documentStore;
        public RavenDbManagement()
        {
            documentStore = new DocumentStore { Url = "http://192.168.0.40:8081/" };
            documentStore.Initialize();
        }

       
        public bool CreateDb(string db)
        {
            try
            {
                documentStore.DatabaseCommands.EnsureDatabaseExists(db, true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<string> GetDocuments()
        {
            var keys = documentStore.DatabaseCommands.GetDocuments(0, 1024, metadataOnly: true)
                            .Select(x => x.Key)
                            .ToList();
            return keys;
        }



        bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            //GC.SuppressFinalize(this);
        }
    }
}







//var keys = store.DatabaseCommands.GetDocuments(0, 1024, metadataOnly: true)
//                .Select(x => x.Key)
//                .ToArray();