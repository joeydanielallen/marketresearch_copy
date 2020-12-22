using afmr.api.Models;
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
    public class ResearchUserController : ApiControllerBase
    {
        private readonly IResearchService _researchService;

        public ResearchUserController(
            IResearchService researchService)
        {
            _researchService = researchService;
        }

        [SwaggerOperation(
          Summary = "Get user for market research form",
          Description = "",
          OperationId = "GetResearchUsers",
          Tags = new[] { "Market Research" }
        )]
        [HttpGet("{templateInstanceId}")]
        [Secure(MarketResearchClaims.UserId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TemplateInstanceUser>> Get(int templateInstanceId)
        {
            var users = _researchService.GetUsers(templateInstanceId);
            
            return Ok(users);
        }

        [SwaggerOperation(
                  Summary = "Delete user from market research form",
                  Description = "",
                  OperationId = "DeleteResearchUser",
                  Tags = new[] { "Market Research" }
              )]
        [HttpDelete("{templateInstanceUserId}")]
        [Secure(MarketResearchClaims.UserId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int templateInstanceUserId)
        {
            _researchService.DeleteUser(templateInstanceUserId);

            return Ok();
        }

        [SwaggerOperation(
          Summary = "Add user to market research form",
          Description = "",
          OperationId = "CreateResearchUser",
          Tags = new[] { "Market Research" }
        )]
        [HttpPost]
        [Secure(MarketResearchClaims.UserId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> Post(int templateInstanceId, int userAccountId)
        {
            if (templateInstanceId < 1 || userAccountId < 1)
            {
                return BadRequest("Arguments must not be greater than 0");
            }

            var newId = _researchService.CreateUser(templateInstanceId, userAccountId);

            return Ok(newId);
        }
    }
}
