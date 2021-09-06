using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item.Response
{
    public class ItemAttributeValueResponse
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

        public ItemAttributeValueResponse(ItemAttributeValue itemAttributeValue)
        {
            AttributeName = itemAttributeValue.ItemTypeAttribute.Name;
            AttributeValue = itemAttributeValue.Value;
        }
    }
}
