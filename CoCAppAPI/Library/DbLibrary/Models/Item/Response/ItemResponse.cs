using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item.Response
{
    public class ItemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string ItemTypeName { get; set; }
        public List<ItemAttributeValueResponse> ItemAttributeValues { get; set; }

        public ItemResponse() { }

        public ItemResponse(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            ItemTypeName = item.ItemType.Name;

            ItemAttributeValues = new List<ItemAttributeValueResponse>();
            foreach (var i in item.ItemAttributeValues)
            {
                ItemAttributeValues.Add(new ItemAttributeValueResponse(i));
            }
        }
    }
}
