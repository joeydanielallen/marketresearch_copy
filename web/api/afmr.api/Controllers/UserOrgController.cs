using afmr.api.Mappers;
using afmr.api.Models;
using afmr.api.Security;
using afmr.domain.Services;
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
    public class UserOrgController : ApiControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserOrgController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [SwaggerOperation(
          Summary = "Get all users in an organization",
          Description = "",
          OperationId = "GetOrgUsers",
          Tags = new[] { "Account" }
      )]
        [HttpGet("{orgId}")]
        //[Secure(MarketResearchClaims.UserId)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UserAccount>> Get(int orgId)
        {
            var users = _userAccountService.GetUsersInOrg(orgId).Map();

            return Ok(users);
        }
    }
}
