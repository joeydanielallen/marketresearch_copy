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
    [Secure(MarketResearchClaims.UserId)]
    public class VendorContactController : ApiControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IAppConfig _config;

        public VendorContactController(
            IVendorService vendorService
            , IAppConfig config)
        {
            _vendorService = vendorService;
            _config = config;
        }


        [SwaggerOperation(
            Summary = "Create Vendor Contact",
            Description = "",
            OperationId = "CreateVendorContact",
            Tags = new[] { "Vendor" }
        )]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> Post(VendorContact contact)
        {
            if (contact == null)
            {
                return base.BadRequest();
            }

            var id = _vendorService.AddContact(contact);

            return Ok(id);
        }

        [SwaggerOperation(
            Summary = "Update Vendor Contact",
            Description = "",
            OperationId = "UpdateVendorContact",
            Tags = new[] { "Vendor" }
        )]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(VendorContact contact)
        {
            if (contact == null)
            {
                return base.BadRequest();
            }

            var result = _vendorService.UpdateContact(contact);
            if(result == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [SwaggerOperation(
            Summary = "Delete Vendor Contact",
            Description = "",
            OperationId = "DeleteVendorContact",
            Tags = new[] { "Vendor" }
        )]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            _vendorService.DeleteContact(id);

            return Ok();
        }
    }
}
