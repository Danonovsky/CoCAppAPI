using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item
{
    public class ItemAttributeValue
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }

        public Guid ItemTypeAttributeId { get; set; }
        public virtual ItemTypeAttribute ItemTypeAttribute { get; set; }
    }
}
