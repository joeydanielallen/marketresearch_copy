using afmr.model.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace afmr.api.Controllers
{
    [AllowAnonymous]
    public class ClaimsController : ApiControllerBase
    {
        public ClaimsController()
        {
        }

        [SwaggerOperation(
            Summary = "Get system claims",
            Description = "Authorizations",
            OperationId = "GetClaims",
            Tags = new[] { "Support" }
        )]
        [SwaggerResponse(200, "Authorization claims for system")]
        [HttpGet]
        public IEnumerable<MarketResearchClaim> Get()
        {
            return MarketResearchClaims.GetClaims();
        }
    }
}
