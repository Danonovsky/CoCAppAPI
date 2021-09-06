using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item.Request
{
    public class ItemRequest
    {
        public string Name { get; set; }
        public Guid ItemTypeId { get; set; }
        public List<ItemAttributeValue> ItemAttributeValues { get; set; }
    }
}
