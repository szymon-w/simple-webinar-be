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
                    Message = "Login is already taken"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is DifferentPasswordsException){
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Two given password do not match each other!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is CodeOccupiedException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Code is already taken!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is UserNotExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Given login does not exist!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is FinishBeforeStartException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Webinar's end has to be later than its start!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is ParticipationNotExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "You are not signed up to this webinar!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is WebinarNotExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Given Webinar does not exist!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is AlreadySignedUpToWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "You are already signed up to this webinar!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is UnhostedWebinarsExistException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Webinars hosted by this user exist! Remove all webinars hosted by this user before!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is NotSignedUpToWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "You are not signed to this webinar!"
                }.ToString());
            }

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is RemoveDoneWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Can't delete webinar which already has finished!"
                }.ToString());
            }


            
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (exception is SignUpToFinishedWebinarException)
            {
                return context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "Can't sign up to webinar which already has finished!"
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
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
}
