using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCMS.Model
{
   public class SliderModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Link { get; set; }
        public short Priority { get; set; }
    }
}
