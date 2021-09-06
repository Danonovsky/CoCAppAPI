using DbLibrary.Models.Item.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item
{
    public class ItemType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ItemTypeAttribute> ItemTypeAttributes { get; set; }

        public ItemType(ItemTypeRequest request)
        {
            Name = request.Name;
        }
    }
}
