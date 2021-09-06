using ItemModule.Services;
using AuthModule.Helpers;
using DbLibrary.Models.Characteristic.Request;
using DbLibrary.Models.Skill.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using DbLibrary.Models.Item.Request;
using DbLibrary.Models.Item;

namespace ItemModule.Controllers
{
    [ApiController]
    [Route("admin/item")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        #region ItemType

        [HttpGet("/itemType/{id}")]
        [Authorize]
        public IActionResult GetItemType(Guid id)
        {
            var result = _service.GetItemType(id);
            return Ok(result);
        }

        [HttpGet("itemType")]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _service.GetItemTypes();
            return Ok(result);
        }

        [HttpPost("itemType")]
        [Authorize]
        public IActionResult Add(ItemTypeRequest model)
        {
            var result = _service.AddItemType(model);
            if (result) return Ok();
            else return BadRequest();
        }

        [HttpDelete("itemType/{id}")]
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            var result = _service.DeleteItemType(id);
            if (result) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update(Guid id, ItemTypeRequest model)
        {
            var result = _service.UpdateItemType(id, model);
            if (result) return Ok(result);
            else return BadRequest(result);
        }
    }

    #endregion


}
