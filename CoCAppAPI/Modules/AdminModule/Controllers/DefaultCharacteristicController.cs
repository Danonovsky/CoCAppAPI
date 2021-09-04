using AdminModule.Services;
using AuthModule.Helpers;
using DbLibrary.Models.Characteristic.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminModule.Controllers
{
    [ApiController]
    [Route("admin/characteristic")]
    public class DefaultCharacteristicController : ControllerBase
    {
        private IDefaultCharacteristicService _service;

        public DefaultCharacteristicController(IDefaultCharacteristicService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(Guid id)
        {
            var result = _service.Get(id);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(DefaultCharacteristicRequest model)
        {
            var result = _service.Add(model);
            if (result) return Ok();
            else return BadRequest();
        }
    }
}
