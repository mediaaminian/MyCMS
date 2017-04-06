namespace MyCMS.Model.LuceneModel
{
    public class LucenePostModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Body { get; set; }
        public string Labels { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
    }
}