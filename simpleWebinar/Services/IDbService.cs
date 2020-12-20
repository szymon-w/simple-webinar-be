using simpleWebinar.DTO.Requests;
using simpleWebinar.DTO.Responses;
//using simpleWebinar.DTO.Responses;
using simpleWebinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Services
{
    public interface IDbService
    {
        public User AddUser(CreateUserRequest request);
        public User SignUp(SignupRequest request);
        public Webinar CreateWebinar(CreateWebinarRequest request);
        public UserWebinar SignUpToWebinar(AddParticipationRequest request, string code);
        public void DeleteUser(string login);
        public void DeleteWebinar(DeleteWebinarRequest request, string code);
        public void DeleteParticipation(DeleteParticipationRequest request, string code);
        public void EditUser(EditUserRequest request, string login);
        public void EditWebinar(EditWebinarRequest request, string code);
        public void EditParticipation(EditParticipationRequest request, string code);
        public UserResponse GetUser(string login);
        public WebinarResponse GetWebinar(string studentLogin, string code);
        public List<UserFromListResponse> GetUsers();
        public List<WebinarFromListResponse> GetWebinars(string studentLogin, string teacherLogin, Boolean finished);
        public ContactMessage CreateContactMessage(CreateContactMessageRequest request);



    }
}
