using DbLibrary.Models.Item.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary.Models.Location.Response
{
    public class LocationItemResponse : ItemResponse
    {
        public Guid LocationItemId { get; set; }

        public LocationItemResponse(LocationItem model)
            :base(model.Item)
        {
            LocationItemId = model.Id;
        }
    }
}
