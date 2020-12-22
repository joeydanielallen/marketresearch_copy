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
    public class UserSearchController : ApiControllerBase
    {

        private readonly IUserAccountService _accountService;

        public UserSearchController(
            IUserAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [SwaggerOperation(
                  Summary = "Get active users",
                  Description = "",
                  OperationId = "GetUsersByName",
                  Tags = new[] { "Account" }
              )]
        [HttpGet]
        [Secure(MarketResearchClaims.ViewMarketResearch)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UserName>> Get(
            [FromQuery] string nameSearchValue,
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize)
        {
            if(string.IsNullOrWhiteSpace(nameSearchValue))
            {
                return Ok(new List<UserName>());
            }

            var users = _accountService.GetUsersByName(
                nameSearchValue, 
                pageNumber,
                pageSize)
                .Select(e => new UserName()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    UserAccountId = e.UserAccountId
                });

            return Ok(users);
        }
    }
}
