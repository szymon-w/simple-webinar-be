using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simpleWebinar.Models;
using simpleWebinar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace simpleWebinar.Controllers
{
    [Route("api/simplewebinar")]
    [ApiController]
    public class SimpleWebinarController : ControllerBase
    {
        private readonly IDbService _context;
        public SimpleWebinarController(IDbService context)
        {
            _context = context;
        }

        [HttpGet("error")]
        public IActionResult sampleMethod()
        {
            _context.sampleMethod();
            return Ok();
        }
    }
}
