using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item
{
    public class ItemTypeAttribute
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid ItemTypeId { get; set; }
        public virtual ItemType ItemType { get; set; }

        public virtual ICollection<ItemAttributeValue> ItemAttributeValues { get; set; }
    }
}
