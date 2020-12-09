using simpleWebinar.DTO.Requests;
using simpleWebinar.Exceptions;
using simpleWebinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Services
{
    public class SimpleWebinarContextDbService : IDbService
    {
        private readonly SimpleWebinarDbContext _context;
        public SimpleWebinarContextDbService(SimpleWebinarDbContext context)
        {
            _context = context;
        }
        public User AddUser(CreateUserRequest request)
        {
            if (_context.Users.Where(x => x.Login == request.Login).Any())
                throw new LoginOccupiedException("");
            if (request.Password != request.Password2)
                throw new DifferentPasswordsException("");
            User user;
            _context.Users.Add(user = new User
            {
                Login = request.Login,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                Password=request.Password,
                IsTeacher=request.IsTeacher,
                IsAdmin=request.IsAdmin
            });
            _context.SaveChanges();
            return user;
        }

        public User SignUp(SignupRequest request)
        {
            var cuRequest = new CreateUserRequest
            {
                Name = "",
                Surname = "",
                Login = request.Login,
                Email = request.Email,
                Password = request.Password,
                Password2 = request.Password2,
                IsAdmin = false,
                IsTeacher = false
            };
            return AddUser(cuRequest);
        }

        public void DeleteUser(string Login)
        {
            if (!UserExists(Login))
                throw new UserNotExistException("");
            User user = _context.Users.Where(x => x.Login == Login).FirstOrDefault();
            if (_context.Webinars.Where(x => x.IdUser == user.IdUser).Any())
                throw new UnhostedWebinarsExistException("");
            _context.Users.Remove(user);
            _context.SaveChanges();
        }





        public Webinar CreateWebinar(CreateWebinarRequest request)
        {
            int IdUser = getIdUserByLogin(request.Login);
            if (_context.Webinars.Where(x => x.Code == request.Code).Any())
                throw new CodeOccupiedException("");
            if (request.FinishTime<request.StartTime)
                throw new FinishBeforeStartException("");

            Webinar webinar;
            _context.Webinars.Add(webinar = new Webinar
            {
                Code=request.Code,
                Topic=request.Topic,
                Date=request.Date.GetValueOrDefault(),
                StartTime=request.StartTime.GetValueOrDefault(),
                EndTime=request.FinishTime.GetValueOrDefault(),
                IdUser=IdUser
            });
            _context.SaveChanges();
            return webinar;
        }


        public UserWebinar SignUpToWebinar(AddParticipationRequest request, string code)
        {
            int IdUser = getIdUserByLogin(request.Login);
            int IdWebinar = getIdWebinarByCode(code);

            if (_context.UserWebinars
                .Where(x => x.IdUser == IdUser)
                .Where(x => x.IdWebinar == IdWebinar).Any())
            {
                throw new AlreadySignedUpToWebinarException("");
            }
            if (_context.Webinars.Where(x => x.Code == code).FirstOrDefault().Date.AddDays(1) < DateTime.Now)
                throw new SignUpToFinishedWebinarException("");

            UserWebinar participation;
            _context.UserWebinars.Add(participation = new UserWebinar
            {
                IdUser = IdUser,
                IdWebinar = IdWebinar,
            });
            _context.SaveChanges();
            return participation;
        }

        public void DeleteWebinar(string code)
        {
            if (!WebinarExists(code))
                throw new WebinarNotExistException("");
            if (_context.Webinars.Where(x => x.Code == code).FirstOrDefault().Date < DateTime.Now)
                throw new RemoveDoneWebinarException("");

            Webinar webinar = _context.Webinars.Where(x => x.Code == code).FirstOrDefault();
            _context.Webinars.Remove(webinar);
            _context.SaveChanges();
        }

        public void DeleteParticipation(DeleteParticipationRequest request, string code)
        {
            if (!WebinarExists(code))
                throw new WebinarNotExistException("");
            if (!UserExists(request.Login))
                throw new UserNotExistException("");
            if (!ParticipationExists(getIdUserByLogin(request.Login), getIdWebinarByCode(code)))
                throw new NotSignedUpToWebinarException("");
            if (_context.Webinars.Where(x => x.Code == code).FirstOrDefault().Date < DateTime.Now)
                throw new RemoveDoneWebinarException("");

            UserWebinar participation = _context.UserWebinars.
                Where(x => x.IdUser == getIdUserByLogin(request.Login)).
                Where(x => x.IdWebinar == getIdWebinarByCode(code)).
                FirstOrDefault();
            _context.UserWebinars.Remove(participation);
            _context.SaveChanges();
        }


        private Boolean ParticipationExists(int IdUser, int IdWebinar)
        {
            return _context.UserWebinars
                .Where(x => x.IdUser == IdUser)
                .Where(x => x.IdWebinar == IdWebinar).Any();
        }

        private Boolean WebinarExists(string Code)
        {
            return (_context.Webinars.Where(x => x.Code == Code).Any());
        }

        private Boolean UserExists(string Login)
        {
            return (_context.Users.Where(x => x.Login == Login).Any());
        }

        private int getIdUserByLogin (string Login)
        {
            if (!UserExists(Login))
                throw new UserNotExistException("");
            return _context.Users.Where(x => x.Login == Login).FirstOrDefault().IdUser;
        }

        private int getIdWebinarByCode(string Code)
        {
            if (!(_context.Webinars.Where(x => x.Code == Code).Any()))
                throw new WebinarNotExistException("");
            return _context.Webinars.Where(x => x.Code == Code).FirstOrDefault().IdWebinar;
        }

        private int getIdParticipationByIds(int IdUser, int IdWebinar)
        {
            if (!(_context.UserWebinars.Where(x => x.IdUser == IdUser).Where(x=>x.IdWebinar==IdWebinar).Any()))
                throw new ParticipationNotExistException("");
            return _context.UserWebinars.Where(x => x.IdUser == IdUser).Where(x => x.IdWebinar == IdWebinar)
                .FirstOrDefault().IdUserWebinar;
        }
    }
}
