using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Research;
using afmr.model.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace afmr.api.Controllers
{
    public class InitiateResearchController : ApiControllerBase
    {
        private readonly IResearchService _researchService;

        public InitiateResearchController(IResearchService service)
        {
            this._researchService = service;
        }

        [SwaggerOperation(
          Summary = "Initiate market research provides suggested templates given input",
          Description = "",
          OperationId = "InitiateResearch",
          Tags = new[] { "Market Research" }
        )]
        [HttpPost]
        [Secure(MarketResearchClaims.InitiateMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InitiateResponse> Post(InitiateRequest request)
        {
            if(null == request)
            {
                return BadRequest("request parameter must be provided");
            }

            var response = _researchService.Initiate(request);
            if(response.SearchQueueResponse != null &&
                response.SearchQueueResponse.ProcessMessage == "Error")
            {
                //Gateway/Client API call error, client can try again
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }

            return Ok(response);
        }
        
        //[SwaggerOperation(
        //  Summary = "Retrieve queued request for Initiate",
        //  Description = "",
        //  OperationId = "Market Research",
        //  Tags = new[] { "Market Research" }
        //)]
        //[HttpGet("{requestId}")]
        //[Secure(MarketResearchClaims.InitiateMarketResearch)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<InitiateResponse> Get(string requestId)
        //{
        //    if (null == requestId)
        //    {
        //        return BadRequest("requestId parameter must be provided");
        //    }

        //    InitiateResponse response = new InitiateResponse();
        //    //TODO call for sustainment queued request
        //    return Ok(response);
        //}
    }
}
