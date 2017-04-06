using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public class PropertyGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public int? ProductTypeGroupID { get; set; }
        public virtual ProductTypeGroup ProductTypeGroup { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}