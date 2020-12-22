using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Security;
using afmr.model.Vendors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace afmr.api.Controllers
{
    public class ResearchVendorsController : ApiControllerBase
    {
        private readonly IResearchService _researchService;
        private readonly IAppConfig _config;

        public ResearchVendorsController(
            IResearchService researchService
            , IAppConfig config)
        {
            _researchService = researchService;
            _config = config;
        }


        [SwaggerOperation(
            Summary = "Get vendors in research form",
            Description = "",
            OperationId = "GetResearchVendor",
            Tags = new[] { "Market Research" }
        )]
        //[Secure(MarketResearchClaims.ViewMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{tempalteInstanceId}")]
        public ActionResult<IEnumerable<ResearchFormVendor>> Get(int tempalteInstanceId)
        {
            if (tempalteInstanceId < 1)
            {
                return BadRequest();
            }

            var vendors = _researchService.GetVendorsSelected(tempalteInstanceId);

            return Ok(vendors);
        }
    }
}
