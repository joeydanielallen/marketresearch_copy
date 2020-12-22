using afmr.api.Security;
using afmr.domain.Services;
using afmr.model.Research;
using afmr.model.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api.Controllers
{
    public class ResearchAnswerController : ApiControllerBase
    {
        private readonly IResearchService _researchService;
        private readonly IAppConfig _config;

        public ResearchAnswerController(
            IResearchService researchService
            , IAppConfig config)
        {
            _researchService = researchService;
            _config = config;
        }

        [SwaggerOperation(
          Summary = "Save all market research answers",
          Description = "",
          OperationId = "SaveResearch",
          Tags = new[] { "Market Research" }
        )]
        [Secure(MarketResearchClaims.ViewMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpPost]
        public ActionResult Post(IEnumerable<TemplateInstanceAnswer> answers)
        {
            if(answers == null || !answers.Any())
            {
                return Ok();
            }

            var tempInstanceId = answers.First().TemplateInstanceId;

            if(answers.Where(e => e.TemplateInstanceId != tempInstanceId).Any())
            {
                return BadRequest();
            }

            if (!_researchService.CanAnswerResearch(tempInstanceId))
            {
                return Forbid();
            }

            _researchService.SaveAnswers(answers);

            return Ok();
        }

        [SwaggerOperation(
          Summary = "Delete market research multiselect answer",
          Description = "",
          OperationId = "Research",
          Tags = new[] { "Market Research" }
        )]
        [Secure(MarketResearchClaims.ViewMarketResearch)]
        [HttpDelete]
        public ActionResult Delete(TemplateInstanceAnswer templateInstanceAnswer,  int multiselectAnswerId)
        {
            if (!_researchService.CanAnswerResearch(templateInstanceAnswer.Id))
            {
                return Forbid();
            }

            _researchService.DeleteMultiselectAnswer(
                templateInstanceAnswer,
                multiselectAnswerId);

            return Ok();
        }
    }
}
