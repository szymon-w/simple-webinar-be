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
    [Route("api/samples")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IDbService _context;
        public SampleController(IDbService context)
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
