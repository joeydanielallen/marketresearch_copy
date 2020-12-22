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
    public class ResearchController : ApiControllerBase
    {
        private readonly IResearchService _researchService;
        private readonly IAppConfig _config;

        public ResearchController(
            IResearchService researchService
            , IAppConfig config)
        {
            _researchService = researchService;
            _config = config;
        }


        [SwaggerOperation(
                  Summary = "Get market research form",
                  Description = "",
                  OperationId = "GetResearch",
                  Tags = new[] { "Market Research" }
              )]
        [HttpGet("{id}")]
        [Secure(MarketResearchClaims.ViewMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<TemplateInstance> Get(int id)
        {
            var templateInstance = _researchService.Get(id);

            if(null == templateInstance)
            {
                NotFound();
            }

            return Ok(templateInstance);
        }

        [SwaggerOperation(
                  Summary = "Toggle Complete market research",
                  Description = "",
                  OperationId = "CompleteResearch",
                  Tags = new[] { "Market Research" }
              )]
        [HttpPut("{id}")]
        [Secure(MarketResearchClaims.ViewMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Put(int id)
        {
            _researchService.ToggleComplete(id);
            
            return Ok();
        }


        [SwaggerOperation(
                  Summary = "Delete market research",
                  Description = "",
                  OperationId = "DeleteResearch",
                  Tags = new[] { "Market Research" }
              )]
        [HttpDelete("{id}")]
        [Secure(MarketResearchClaims.ViewMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            _researchService.Delete(id);

            return Ok();
        }
    }
}
