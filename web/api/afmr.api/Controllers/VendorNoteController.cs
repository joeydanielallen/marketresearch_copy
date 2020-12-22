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
    public class VendorNoteController : ApiControllerBase
    {
        private readonly IVendorNoteService _vendorNoteService;
        private readonly IAppConfig _config;

        public VendorNoteController(
            IVendorNoteService vendorNoteService
            , IAppConfig config)
        {
            _vendorNoteService = vendorNoteService;
            _config = config;
        }

        [SwaggerOperation(
            Summary = "Get Vendor Note",
            Description = "",
            OperationId = "GetVendorNote",
            Tags = new[] { "Vendor" }
        )]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VendorNote> Get(int id)
        {
            var note = _vendorNoteService.Get(id);
            if(note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [SwaggerOperation(
            Summary = "Create Vendor Note",
            Description = "",
            OperationId = "CreateVendorNote",
            Tags = new[] { "Vendor" }
        )]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> Post(VendorNote note)
        {
            if(note == null)
            {
                return base.BadRequest();
            }

            var id = _vendorNoteService.Create(note);

            return Ok(id);
        }

        [SwaggerOperation(
            Summary = "Update Vendor Note",
            Description = "",
            OperationId = "UpdateVendorNote",
            Tags = new[] { "Vendor" }
        )]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Put(VendorNote note)
        {
            if (note == null)
            {
                return base.BadRequest();
            }

            var response = _vendorNoteService.Update(note);
            if(response == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [SwaggerOperation(
            Summary = "Delete Vendor Note",
            Description = "",
            OperationId = "DeleteVendorNote",
            Tags = new[] { "Vendor" }
        )]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            _vendorNoteService.Delete(id);

            return Ok();
        }
    }
}
