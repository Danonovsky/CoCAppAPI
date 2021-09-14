using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RollModule.Models;
using RollModule.Services;

namespace RollModule.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RollController : ControllerBase
    {
        public IRollService _rollService;
        public RollController(IRollService rollService)
        {
            _rollService = rollService;
        }

        [HttpPost]
        public IActionResult GetRoll(RollRequest roll)
        {
            var result = _rollService.GetRoll(roll);
            return Ok(result);
        }

        [HttpPost("many")]
        public IActionResult GetRolls(List<RollRequest> roll)
        {
            var result = _rollService.GetRoll(roll);
            return Ok(result);
        }
    }
}
