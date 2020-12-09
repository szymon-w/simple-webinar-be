using simpleWebinar.DTO.Requests;
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
        public void DeleteWebinar(string code);
        public void DeleteParticipation(DeleteParticipationRequest request, string code);


    }
}
