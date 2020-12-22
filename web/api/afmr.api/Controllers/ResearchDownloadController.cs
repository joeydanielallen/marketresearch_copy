using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using afmr.api.Security;
using afmr.domain.Services;
using afmr.model;
using afmr.model.Security;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace afmr.api.Controllers
{
    //[Secure(MarketResearchClaims.UserId)]
    public class ResearchDownloadController : ApiControllerBase
    {
        private readonly IResearchPdfService _researchPdfService;

        public ResearchDownloadController(
            IResearchPdfService researchPdfService,
            ILogger logger)
        {
            _researchPdfService = researchPdfService;
        }

        [SwaggerOperation(
            Summary = "Get Research Download",
            Description = "",
            OperationId = "GetResearchDownload",
            Tags = new[] { "Market Research" }
        )]
        [SwaggerResponse(StatusCodes.Status200OK, "Download PDF.", typeof(FileContentResult))]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public FileStreamResult Get(int id)
        {
            var fileStream = _researchPdfService.GetResearchFormPdf(id);

            return File(fileStream, "application/pdf");
        }
    }
}
