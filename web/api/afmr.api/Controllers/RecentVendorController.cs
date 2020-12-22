using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Security;
using afmr.model.Vendors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace afmr.api.Controllers
{
    public class RecentVendorController : ApiControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IAppConfig _config;

        public RecentVendorController(
            IVendorService vendorService
            , IAppConfig config)
        {
            _vendorService = vendorService;
            _config = config;
        }

        [SwaggerOperation(
         Summary = "Get recent vendors viewed by user",
         Description = "",
         OperationId = "GetRecentVendor",
         Tags = new[] { "Vendor" }
       )]
        [Secure(MarketResearchClaims.UserId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet()]
        public ActionResult<IEnumerable<Vendor>> Get([FromQuery] int? count)
        {
            var recents = _vendorService.GetRecents(count.HasValue ? count.Value : 10);

            return Ok(recents);
        }
    }
}
