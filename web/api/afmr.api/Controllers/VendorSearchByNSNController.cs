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
using System.Net;
using System.Threading.Tasks;

namespace afmr.api.Controllers
{
    public class VendorSearchByNSNController : ApiControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IAppConfig _config;

        public VendorSearchByNSNController(
            IVendorService vendorService
            , IAppConfig config)
        {
            _vendorService = vendorService;
            _config = config;
        }

        [SwaggerOperation(
            Summary = "Search Vendors By NSN",
            Description = "",
            OperationId = "SearchVendorByNsn",
            Tags = new[] { "Vendor" }
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Secure(MarketResearchClaims.UserId)]
        [HttpGet("{nsn}")]
        public ActionResult<IEnumerable<VendorSearch>> Get(string nsn)
        {
            if(string.IsNullOrWhiteSpace(nsn) || 
                nsn.Length != 13)
            {
                return BadRequest("NSN search must be 13 characters");
            }

            var vendors = _vendorService.SearchByNsn(nsn, out var httpStatus);

            if(httpStatus != HttpStatusCode.OK)
            {
                return StatusCode((int)httpStatus);
            }

            if(vendors == null)
            {
                return NotFound();
            }

            return Ok(vendors);
        }
    }
}
