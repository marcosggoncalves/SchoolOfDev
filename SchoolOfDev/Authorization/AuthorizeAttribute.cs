using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolOfDev.DTO.User;
using SchoolOfDev.Enuns;

namespace SchoolOfDev.Authorization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<TypeUser> _roles;
        public AuthorizeAttribute(params TypeUser[] roles)
        {
            _roles = roles ?? new TypeUser[] {};
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            if (allowAnonymous) 
                return;

            var user = (UserResponse)context.HttpContext.Items["User"];

            if (user == null || (_roles.Any() && !_roles.Contains(user.TypeUser)))
            {
                context.Result = new JsonResult(new { message = "Você não permissão para acessar api." })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }

        }
    }
}
