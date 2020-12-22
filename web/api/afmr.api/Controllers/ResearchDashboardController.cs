using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Research;
using afmr.model.Security;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api.Controllers
{
    public class ResearchDashboardController : ApiControllerBase
    {
        private readonly IResearchService _researchService;
        private readonly IAppConfig _config;

        public ResearchDashboardController(
            IResearchService researchService
            , IAppConfig config)
        {
            _researchService = researchService;
            _config = config;
        }

        [SwaggerOperation(
            Summary = "Get market research summaries",
            Description = "",
            OperationId = "GetResearchSummary",
            Tags = new[] { "Market Research" }
        )]
        [HttpGet]
        [Secure(MarketResearchClaims.UserId)]
        public ActionResult<IEnumerable<TemplateInstanceSummary>> Get([FromQuery] bool onlyInProgress = false)
        {
            var templateInstances = _researchService.GetSummaries(onlyInProgress);

            return Ok(templateInstances);
        }
    }
}
