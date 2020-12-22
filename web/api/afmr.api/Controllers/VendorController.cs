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
    public class VendorController : ApiControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IAppConfig _config;

        public VendorController(
            IVendorService vendorService
            , IAppConfig config)
        {
            _vendorService = vendorService;
            _config = config;
        }

        [SwaggerOperation(
            Summary = "Get Vendor",
            Description = "",
            OperationId = "GetVendor",
            Tags = new[] { "Vendor" }
        )]
        [HttpGet("{id}")]
        //[Secure(MarketResearchClaims.UserId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Vendor> Get(string id)
        {
            var vendor = _vendorService.Get(id);

            if (null == vendor)
            {
                NotFound();
            }

            return Ok(vendor);
        }
    }
}
