using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
   public class CurrencyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public int Price { get; set; }
        public string Icon { get; set; }
        public short Priority { get; set; }
    }
}
