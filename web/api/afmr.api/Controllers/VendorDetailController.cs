using afmr.domain.Services;
using afmr.model.Vendors.Sustainment;
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
    public class VendorDetailController : ApiControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IAppConfig _config;

        public VendorDetailController(
            IVendorService vendorService
            , IAppConfig config)
        {
            _vendorService = vendorService;
            _config = config;
        }

        [SwaggerOperation(
            Summary = "Vendor Detail",
            Description = "",
            OperationId = "GetVendorDetail",
            Tags = new[] { "Vendor" }
        )]
        [HttpGet("{sustainmentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[Secure(MarketResearchClaims.UserId)]
        public ActionResult<SustainmentVendor> Get(string sustainmentId)
        {
            if(string.IsNullOrEmpty(sustainmentId))
            {
                return BadRequest();
            }

            var vendor = _vendorService.GetVendorDetail(sustainmentId, out var httpStatusCode);

            if(httpStatusCode != HttpStatusCode.OK)
            {
                return StatusCode((int)httpStatusCode);
            }

            if (null == vendor)
            {
                NotFound();
            }

            return Ok(vendor);
        }
    }
}
