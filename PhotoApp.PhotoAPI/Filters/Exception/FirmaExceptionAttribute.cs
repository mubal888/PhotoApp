using DTO.DtoModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhotoApp.PhotoAPI.Models;
using System;
using System.IO;

namespace PhotoApp.PhotoAPI.Filters.Exception
{
    public class FirmaExceptionAttribute : ExceptionFilterAttribute  
    {
        public override void OnException(ExceptionContext context)
        {
              
            ServiceResponse<FirmaDto.Firma> response = new()
            {
                HasError = true
            };          
            response.ErrorsAndWarnings.Add("Bir hata oluştu: " + context.Exception.Message);
            context.Result = new BadRequestObjectResult(response);
             
        }
         
    }  
    //public class FirmaExceptionAttribute : ActionFilterAttribute
    //{
    //    public override void OnException(ExceptionContext context)
    //    {
              
    //        ServiceResponse<FirmaDto> response = new()
    //        {
    //            HasError = true
    //        };          
    //        response.ErrorsAndWarnings.Add("Bir hata oluştu: " + context.Exception.Message);
    //        context.Result = new BadRequestObjectResult(response);
             
    //    }
         
    //}
}
