using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simpleWebinar.Models;
using simpleWebinar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simpleWebinar.DTO.Requests;
using simpleWebinar.DTO.Responses;

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
            return Created("", "User was succesfully created");
        }

        [HttpPost("signup")]

        public IActionResult SingUp(SignupRequest request)
        {
            Console.WriteLine(request.Login+" "+request.Password);
            User user = _context.SignUp(request);
            return Created("", "You signed up successfully");
        }


        [HttpDelete("users/{login}")]
        public IActionResult DeleteUser(string login)
        {
            _context.DeleteUser(login);
            return Ok("User was succesfully deleted");
        }


        [HttpPut("users/{login}")]
        public IActionResult EditUser(EditUserRequest request, string login)
        {
            _context.EditUser(request, login);
            return Ok("User was succesfully modified");
        }

        [HttpGet("users")]
        public IActionResult GetUser()
        {
            var userListResponse = _context.GetUsers();
            return Ok(userListResponse);
        }

        [HttpGet("users/{login}")]
        public IActionResult GetUser(string login)
        {
            var userResponse = _context.GetUser(login);
            return Ok(userResponse);
        }




        [HttpPost("webinars")]
        public IActionResult CreateWebinar(CreateWebinarRequest request)
        {
            Webinar webinar = _context.CreateWebinar(request);
            return Created("", "Webinar was successfully created");
        }

        [HttpDelete("webinars/{code}")]
        public IActionResult DeleteWebinar(DeleteWebinarRequest request, string code)
        {
            _context.DeleteWebinar(request, code);
            return Ok("Webinar was successfully deleted!");
        }

        [HttpPut("webinars/{code}")]
        public IActionResult EditWebinar(EditWebinarRequest request, string code)
        {
            _context.EditWebinar(request, code);
            return Ok("Webinar was succesfully modified");
        }

        [HttpGet("webinars/{code}")]
        public IActionResult GetWebinar(GetWebinarRequest request, string code)
        {
            var webinarResponse = _context.GetWebinar(request, code);
            return Ok(webinarResponse);
        }

        [HttpGet("webinars/future")]
        public IActionResult GetPlannedWebinars(GetWebinarsRequest request)
        {
            var webinarResponse = _context.GetWebinars(request, null, false);
            return Ok(webinarResponse);
        }

        [HttpGet("webinars/future/{teacherCode}")]
        public IActionResult GetPlannedWebinarsByTeacher(GetWebinarsRequest request, string teacherCode)
        {
            var webinarResponse = _context.GetWebinars(request, teacherCode, false);
            return Ok(webinarResponse);
        }

        [HttpGet("webinars/past/{teacherCode}")]
        public IActionResult GetFinishedWebinarsByTeacher(GetWebinarsRequest request, string teacherCode)
        {
            var webinarResponse = _context.GetWebinars(request, teacherCode, true);
            return Ok(webinarResponse);
        }

        [HttpGet("webinars/future/student")]
        public IActionResult GetPlannedWebinarsByStudent(GetWebinarsRequest request)
        {
            var webinarResponse = _context.GetWebinars(request, null, false);
            return Ok(webinarResponse);
        }

        [HttpGet("webinars/past/student")]
        public IActionResult GetFinishedWebinarsByStudent(GetWebinarsRequest request)
        {
            var webinarResponse = _context.GetWebinars(request, null, true);
            return Ok(webinarResponse);
        }




        [HttpPost("participations/{code}")]
        public IActionResult SignUpToWebinar(AddParticipationRequest request, string code)
        {
            UserWebinar participation = _context.SignUpToWebinar(request, code);
            return Created("", "You signed up to webinar successfully");
        }

        [HttpDelete("participations/{code}")]
        public IActionResult DeleteParticipation(DeleteParticipationRequest request, string code)
        {
            _context.DeleteParticipation(request, code);
            return Ok("You were successfully signed out!");
        }

        [HttpPut("participations/{code}")]
        public IActionResult NoteWebinar(EditParticipationRequest request, string code)
        {
            _context.EditParticipation(request, code);
            return Ok("Webinar was succesfully noted!");
        }




        [HttpPost("messages")]
        public IActionResult CreateMessage(CreateContactMessageRequest request)
        {
            ContactMessage webinar = _context.CreateContactMessage(request);
            return Created("", "Message was successfully sent");
        }



    }
}
