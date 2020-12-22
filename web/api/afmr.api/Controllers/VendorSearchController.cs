using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Research;
using afmr.model.Security;
using afmr.model.Vendors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api.Controllers
{
    public class VendorSearchController : ApiControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IAppConfig _config;

        public VendorSearchController(
            IVendorService vendorService
            , IAppConfig config)
        {
            _vendorService = vendorService;
            _config = config;
        }

        [SwaggerOperation(
            Summary = "Search Vendors",
            Description = "",
            OperationId = "SearchVendor",
            Tags = new[] { "Vendor" }
        )]
        [Secure(MarketResearchClaims.UserId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{nameOrCageOrDuns}")]
        public ActionResult<IEnumerable<Vendor>> Get(string nameOrCageOrDuns)
        {
            if(string.IsNullOrWhiteSpace(nameOrCageOrDuns))
            {
                return BadRequest("Name or CAGE or DUNS must exist");
            }

            var vendors = _vendorService.Search(nameOrCageOrDuns);

            if (null == vendors)
            {
                NotFound();
            }

            return Ok(vendors);
        }
    }
}
