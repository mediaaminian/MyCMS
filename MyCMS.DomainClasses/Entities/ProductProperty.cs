using System;
using System.Collections.Generic;

namespace MyCMS.DomainClasses.Entities
{
    public class ProductProperty
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool UseDefaultValue { get; set; }
        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }
        public byte Status { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}