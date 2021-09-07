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

        #region Item

        [HttpGet("item/{id}")]
        [Authorize]
        public IActionResult GetItem(Guid id)
        {
            var result = _service.GetItem(id);
            return Ok(result);
        }

        [HttpGet("item")]
        [Authorize]
        public IActionResult GetAllItems()
        {
            var result = _service.GetItems();
            return Ok(result);
        }

        [HttpPost("item")]
        [Authorize]
        public IActionResult AddItem(ItemRequest model)
        {
            var result = _service.AddItem(model);
            if (result) return Ok();
            else return BadRequest();
        }

        [HttpDelete("item/{id}")]
        [Authorize]
        public IActionResult DeleteItem(Guid id)
        {
            var result = _service.DeleteItem(id);
            if (result) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateItem(Guid id, ItemRequest model)
        {
            var result = _service.UpdateItem(id, new Item(model));
            if (result) return Ok(result);
            else return BadRequest(result);
        }

        #endregion

        #region ItemType

        [HttpGet("itemType/{id}")]
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

        #endregion

        #region ItemTypeAttribute

        [HttpGet("itemTypeAttribute/{id}")]
        [Authorize]
        public IActionResult GetItemTypeAttribute(Guid id)
        {
            var result = _service.GetItemType(id);
            return Ok(result);
        }

        [HttpGet("itemTypeAttribute/all/{id}")]
        [Authorize]
        public IActionResult GetAllItemTypeAttributes(Guid id)
        {
            var result = _service.GetItemTypeAttributes(id);
            return Ok(result);
        }

        [HttpPost("itemTypeAttribute")]
        [Authorize]
        public IActionResult Add(ItemTypeAttributeRequest model)
        {
            var result = _service.AddItemTypeAttribute(model);
            if (result) return Ok();
            else return BadRequest();
        }

        [HttpDelete("itemTypeAttribute/{id}")]
        [Authorize]
        public IActionResult DeleteItemTypeAttribute(Guid id)
        {
            var result = _service.DeleteItemTypeAttribute(id);
            if (result) return Ok(result);
            else return BadRequest(result);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateItemTypeAttribute(Guid id, ItemTypeAttributeRequest model)
        {
            var result = _service.UpdateItemTypeAttribute(id, model);
            if (result) return Ok(result);
            else return BadRequest(result);
        }

        #endregion
    }
}
