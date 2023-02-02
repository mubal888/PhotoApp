using DTO.DtoModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhotoApp.PhotoAPI.Models;
using System.Linq;

namespace PhotoApp.PhotoAPI.Filters.Validation
{
    public class UserValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ServiceResponse<UserDto.User> response = new ServiceResponse<UserDto.User>
                {
                    ErrorsAndWarnings = context.ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage).ToList(),
                    HasError = true
                };
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
