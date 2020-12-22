using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using afmr.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace afmr.api.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class SecureAttribute : Attribute, IActionFilter
    {
        private string ClaimType;
        private string ClaimValue;

        public SecureAttribute(string claimType, string claimValue = null)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            var hasClaim = httpContext.User.Claims.Any(c => c.Type == ClaimType && c.Value == (ClaimValue ?? c.Value));

            if (!hasClaim)
            {
                try
                {
                    var logger = (ILogger)httpContext.RequestServices.GetService(typeof(ILogger));
                    logger.LogError(
                        "Authorization failure. This should never happen unless a security breach attempt is made. ClaimType=" + 
                        ClaimType + ", ClaimValue=" + ClaimValue + "\nUser=" + JsonConvert.SerializeObject(httpContext.User));
                }
                catch (Exception e)
                {
                }

                context.Result = new StatusCodeResult(401);
            }
        }
    }
}
