using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Item.Request
{
    public class ItemTypeAttributeRequest
    {
        public string Name { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}
