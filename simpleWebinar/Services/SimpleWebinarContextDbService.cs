using simpleWebinar.DTO.Requests;
using simpleWebinar.DTO.Responses;
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

        public void EditUser(EditUserRequest request, string login)
        {
            if (!UserExists(login))
                throw new UserNotExistException("");
            if (request.Password != request.Password2)
                throw new DifferentPasswordsException("");
            User user = _context.Users.Where(x => x.Login == login).FirstOrDefault();
            user.Email = request.Email;
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Password = request.Password;
            user.IsTeacher = request.IsTeacher;
            user.IsAdmin = request.IsAdmin;
            _context.SaveChanges();
        }

        public List<UserFromListResponse> GetUsers()
        {
            var userList = new List<UserFromListResponse>();
            foreach(User user in _context.Users)
            {
                userList.Add(new UserFromListResponse
                {
                    Login = user.Login,
                    IsTeacher = user.IsTeacher,
                    IsAdmin = user.IsAdmin
                });
            }
            return userList;
        }

        public UserResponse GetUser(string login)
        {
            if (!UserExists(login))
                throw new UserNotExistException("");
            User user = _context.Users.Where(x => x.Login == login).FirstOrDefault();
            var userResponse = new UserResponse
            {
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                IsAdmin = user.IsAdmin,
                IsTeacher = user.IsTeacher
            };
            return userResponse;
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


        
        public void DeleteWebinar(DeleteWebinarRequest request, string code)
        {
            if (!WebinarExists(code))
                throw new WebinarNotExistException("");
            Webinar webinar = _context.Webinars.Where(x => x.Code == code).FirstOrDefault();
            if (webinar.Date < DateTime.Now)
                throw new DoneWebinarException("");
            if (webinar.IdUser != getIdUserByLogin(request.Login))
                throw new WebinarNotHostedByGivenUserException("");
            _context.Webinars.Remove(webinar);
            _context.SaveChanges();
        }

        public void EditWebinar(EditWebinarRequest request, string code)
        {
            if (!WebinarExists(code))
                throw new WebinarNotExistException("");
            Webinar webinar = _context.Webinars.Where(x => x.Code == code).FirstOrDefault();
            if (webinar.Date < DateTime.Now)
                throw new DoneWebinarException("");
            if (webinar.IdUser != getIdUserByLogin(request.Login))
                throw new WebinarNotHostedByGivenUserException("");
            if (request.FinishTime<request.StartTime)
                throw new FinishBeforeStartException("");

            webinar.Topic = request.Topic;
            webinar.Date = request.Date.GetValueOrDefault();
            webinar.StartTime = request.StartTime.GetValueOrDefault();
            webinar.EndTime = request.FinishTime.GetValueOrDefault();
            _context.SaveChanges();
        }

        public List<WebinarFromListResponse> GetWebinars (GetWebinarsRequest request, string TeacherLogin, Boolean finished)
        {
            User user=null;
            if (!(request.Login == null))
            {
                if (!UserExists(request.Login))
                    throw new UserNotExistException("");
                user = _context.Users.Where(x => x.Login == request.Login).FirstOrDefault();
            }

            User teacher=null;
            if (!(TeacherLogin == null))
            {
                if (!UserExists(TeacherLogin))
                    throw new UserNotExistException("");
                teacher = _context.Users.Where(x => x.Login == TeacherLogin).FirstOrDefault();
            }
            
            
            var webinars = _context.Webinars.Where(x=>x.IdUser==x.IdUser);
            if (finished)
                webinars = _context.Webinars.Where(x => x.Date <= DateTime.Now);
            else
                webinars = _context.Webinars.Where(x => x.Date > DateTime.Now);

            if (TeacherLogin != null)
                webinars = webinars
                  .Where(x => x.IdUser == getIdUserByLogin(TeacherLogin));

            if (request.Login != null)
            {
                int idStudent = getIdUserByLogin(request.Login);
                webinars =
                    from UserWebinar in _context.UserWebinars
                    join Webinar in webinars on UserWebinar.IdWebinar equals Webinar.IdWebinar
                    where UserWebinar.IdUser==idStudent 
                    select Webinar;
            }

            if(finished)
                webinars = webinars.OrderByDescending(x => x.Date).Take(request.Number);
            else
                webinars = webinars.OrderBy(x => x.Date).Take(request.Number);

            var webinarList = webinars.ToList();
            var webinarsReponse = new List<WebinarFromListResponse>();
            foreach (Webinar w in webinarList)
            {

                webinarsReponse.Add(new WebinarFromListResponse
                {
                    Code = w.Code,
                    Date = w.Date,
                    Teacher = _context.Users.Where(x=>x.IdUser==w.IdUser).FirstOrDefault().Surname
                        + " " + _context.Users.Where(x=>x.IdUser==w.IdUser).FirstOrDefault().Name,
                    Topic = w.Topic
                });
            }
            return webinarsReponse;
        }

        public WebinarResponse GetWebinar(GetWebinarRequest request, string code)
        {
            if (!WebinarExists(code))
                throw new WebinarNotExistException("");
            Webinar webinar = _context.Webinars.Where(x => x.Code == code).FirstOrDefault();

            User user;
            if (!(request.Login == null))
            {
                if (!UserExists(request.Login))
                    throw new UserNotExistException("");
                user = _context.Users.Where(x => x.Login == request.Login).FirstOrDefault();
            }

            int? idTeacher = _context.Webinars.Where(x => x.Code == code).FirstOrDefault().IdUser;
            string teacher = null;
            if (!(idTeacher == null))
            {
                teacher = _context.Users.Where(x => x.IdUser == idTeacher).FirstOrDefault().Name
                    + " " + _context.Users.Where(x => x.IdUser == idTeacher).FirstOrDefault().Surname;
            }

            UserWebinar participation = null;
            int? note = null;
            Boolean isNotedByUser = false;
            Boolean isUserSignedUp = false;
            if (ParticipationExists(getIdUserByLogin(request.Login), getIdWebinarByCode(code))) { 
                participation = _context.UserWebinars.Where(x => x.IdUser == getIdUserByLogin(request.Login))
                   .Where(x => x.IdWebinar == getIdWebinarByCode(code)).FirstOrDefault();
                isUserSignedUp = true;
                note = (int?)participation.Note;
                if (note != null)
                    isNotedByUser = true;
            }

            Boolean isUserATeacher = false;
            if (idTeacher == getIdUserByLogin(request.Login))
                isUserATeacher = true;

            Boolean isFinished = false;
            if (DateTime.Now > webinar.Date.AddDays(1))
                isFinished = true;


            var webinarResponse = new WebinarResponse
            {
                Topic=webinar.Topic,
                Code=webinar.Code,
                Date=webinar.Date,
                Start=webinar.StartTime,
                End=webinar.EndTime,
                Teacher=teacher,
                Note=note,
                IsFinished=isFinished,
                IsNotedByUser=isNotedByUser,
                IsUserATeacher=isUserATeacher,
                IsUserSignedUp=isUserSignedUp           
            };
            return webinarResponse;
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

        public void DeleteParticipation(DeleteParticipationRequest request, string code)
        {
            if (!WebinarExists(code))
                throw new WebinarNotExistException("");
            if (!UserExists(request.Login))
                throw new UserNotExistException("");
            if (!ParticipationExists(getIdUserByLogin(request.Login), getIdWebinarByCode(code)))
                throw new NotSignedUpToWebinarException("");
            if (_context.Webinars.Where(x => x.Code == code).FirstOrDefault().Date < DateTime.Now)
                throw new DoneWebinarException("");

            UserWebinar participation = _context.UserWebinars.
                Where(x => x.IdUser == getIdUserByLogin(request.Login)).
                Where(x => x.IdWebinar == getIdWebinarByCode(code)).
                FirstOrDefault();
            _context.UserWebinars.Remove(participation);
            _context.SaveChanges();
        }

        public void EditParticipation(EditParticipationRequest request, string code)
        {
            int IdUser = getIdUserByLogin(request.Login);
            int IdWebinar = getIdWebinarByCode(code);
            if (!ParticipationExists(IdUser,IdWebinar))
                throw new NotSignedUpToWebinarException("");
            if (_context.Webinars.Where(x => x.Code == code).FirstOrDefault().Date > DateTime.Now)
                throw new NotFinishedWebinarException("");

            UserWebinar participation = _context.UserWebinars.
                Where(x => x.IdUser == IdUser).
                Where(x => x.IdWebinar == IdWebinar).FirstOrDefault();

            participation.Note = (UserWebinar.NoteName)request.Note;
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
