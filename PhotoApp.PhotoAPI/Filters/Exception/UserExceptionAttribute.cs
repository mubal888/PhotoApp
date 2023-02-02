using DTO.DtoModel;
using Microsoft.AspNetCore.Diagnostics; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhotoApp.PhotoAPI.Models;
using System;
using System.IO;

namespace PhotoApp.PhotoAPI.Filters.Exception
{
    public class UserExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
         
            ServiceResponse<UserDto.User> response = new()
            {
                HasError = true
            }; 
            response.ErrorsAndWarnings.Add("Bir hata oluştu: " + context.Exception.Data);
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
