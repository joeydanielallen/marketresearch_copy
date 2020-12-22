using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using afmr.model;
using afmr.model.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace afmr.api.Controllers
{
    /// <summary>
    /// Support services access
    /// </summary>
    public class SupportController : ApiControllerBase
    {

        public SupportController(domain.Services.IResearchService service)
        {
        }

        [SwaggerOperation(
            Summary = "Get system status",
            Description = "Anonymous privileges",
            OperationId = "GetSupport",
            Tags = new[] { "Support" }
        )]
        [SwaggerResponse(200, "The status of the system")]
        [HttpGet]
        public ActionResult<SystemStatus> Get()
        {
            var supportModel = new SystemStatus() { Status = "System is fully available." };

            return supportModel;
        }
    }
}
