using System;

namespace MyCMS.Model.RSSModel
{
    public class RssCurrencyModel 
    {
        public string Title { get; set; }
        public string Keyword { get; set; }
        public int Price { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}