using DbLibrary.Models.Item.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid ItemTypeId { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<ItemAttributeValue> ItemAttributeValues { get; set; }

        public Item() { }
        public Item(ItemRequest request)
        {
            Name = request.Name;
            ItemTypeId = request.ItemTypeId;
        }
    }
}
