using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCMS.DomainClasses.Entities
{
    public class ProductProperty
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool UseDefaultValue { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
        public int PropertyId { get; set; }

        public byte Status { get; set; }
        public virtual byte[] RowVersion { get; set; }
    }
}