using simpleWebinar.ErrrorModels;
using simpleWebinar.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace simpleWebinar.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is LoginOccupiedException){
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Login is already taken"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is DifferentPasswordsException){
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Two given password do not match each other!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is CodeOccupiedException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Code is already taken!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            if (exception is UserNotExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Given login does not exist!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is FinishBeforeStartException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Webinar's end has to be later than its start!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            if (exception is ParticipationNotExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "You are not signed up to this webinar!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            if (exception is WebinarNotExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Given Webinar does not exist!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is AlreadySignedUpToWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "You are already signed up to this webinar!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is AlreadyNotedWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "You have already noted this webinar!"
                }.ToString());
            }


            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is UnhostedWebinarsExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Webinars hosted by this user exist! Remove all webinars hosted by this user before!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            if (exception is NotSignedUpToWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "You are not signed to this webinar!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is DoneWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Can't edit or delete webinar which already has finished!"
                }.ToString());
            }


            
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is SignUpToFinishedWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Can't sign up to webinar which already has finished!"
                }.ToString());
            }

            
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is WebinarNotHostedByGivenUserException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Can't edit or delete webinar which is not hosted by you!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is NotFinishedWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Can't note unfinished webinar!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is PasswordsNotMatchException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    ErrorMessage = "Given password is incorrect!"
                }.ToString());
            }

            

            /*if (exception is SampleException){
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode =(int)HttpStatusCode.BadRequest,
                    Message = "Inny blad"
                }.ToString());
            }*/

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
}
