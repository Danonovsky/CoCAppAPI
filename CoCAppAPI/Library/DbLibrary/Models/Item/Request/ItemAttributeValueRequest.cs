using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item.Request
{
    public class ItemAttributeValueRequest
    {
        public string Value { get; set; }
        public Guid ItemTypeAttributeId { get; set; }
    }
}
