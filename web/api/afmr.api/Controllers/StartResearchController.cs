using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Research;
using afmr.model.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace afmr.api.Controllers
{
    public class StartResearchController : ApiControllerBase
    {
        private readonly IResearchService _researchService;

        public StartResearchController(IResearchService service)
        {
            this._researchService = service;
        }

        [SwaggerOperation(
                  Summary = "Start market research with initiate results, chosen template, and possibly reason for choosing another template",
                  Description = "",
                  OperationId = "StartResearch",
                  Tags = new[] { "Market Research" }
              )]
        [HttpPost]
       // [Secure(MarketResearchClaims.StartMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> Post(StartResearchRequest request)
        {
            var result = _researchService.Start(request);

            if(result.ValidationErrors.Any())
            {
                return BadRequest("Validation failures: " + string.Join(", ", result.ValidationErrors.ToArray()));
            }

            return Ok(result.TemplateInstanceId);
        }
    }
}
