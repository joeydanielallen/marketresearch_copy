using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api.Controllers
{
    public class ResearchNameController : ApiControllerBase
    {
        private readonly IResearchService _researchService;

        public ResearchNameController(
            IResearchService researchService)
        {
            _researchService = researchService;
        }

        [SwaggerOperation(
          Summary = "Update market research name",
          Description = "",
          OperationId = "UpdateResearchName",
          Tags = new[] { "Market Research" }
      )]
        [HttpPut]
        [Secure(MarketResearchClaims.ViewMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Put(int templateInstanceId, string name)
        {
            _researchService.UpdateName(templateInstanceId, name);

            return Ok();
        }
    }
}
