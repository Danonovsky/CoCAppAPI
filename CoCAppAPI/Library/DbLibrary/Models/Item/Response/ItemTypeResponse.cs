using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item.Response
{
    public class ItemTypeResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ItemTypeResponse() { }
        public ItemTypeResponse(ItemType itemType)
        {
            Id = itemType.Id;
            Name = itemType.Name;
        }
    }

}
