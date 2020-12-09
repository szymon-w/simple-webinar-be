using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simpleWebinar.Models;
using simpleWebinar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simpleWebinar.DTO.Requests;

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

        [HttpPost("users")]
        public IActionResult AddUser(CreateUserRequest request)
        {
            User user = _context.AddUser(request);
            return Created("User was succesfully created", user);
        }

        [HttpPost("signup")]
        public IActionResult SingUp(SignupRequest request)
        {
            User user = _context.SignUp(request);
            return Created("You signed up successfully", user);
        }


        [HttpDelete("users/{login}")]
        public IActionResult DeleteUser(string login)
        {
            _context.DeleteUser(login);
            return Ok("User was succesfully deleted");
        }




        [HttpPost("webinars")]
        public IActionResult CreateWebinar(CreateWebinarRequest request)
        {
            Webinar webinar = _context.CreateWebinar(request);
            return Created("Webinar was successfully created", null);
        }

        [HttpDelete("webinars/{code}")]
        public IActionResult DeleteWebinar(string code)
        {
            _context.DeleteWebinar(code);
            return Ok("Webinar was successfully deleted!");
        }


        [HttpPost("participations/{code}")]
        public IActionResult SignUpToWebinar(AddParticipationRequest request, string code)
        {
            UserWebinar participation = _context.SignUpToWebinar(request, code);
            return Created("You signed up to webinar successfully", null);
        }

        [HttpDelete("participations/{code}")]
        public IActionResult DeleteParticipation(DeleteParticipationRequest request, string code)
        {
            _context.DeleteParticipation(request, code);
            return Ok("You were successfully signed out!");
        }




    }
}
