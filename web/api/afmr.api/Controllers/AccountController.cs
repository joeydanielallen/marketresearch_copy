using afmr.api.Mappers;
using afmr.api.Models;
using afmr.domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace afmr.api.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiControllerBase
    {
        private readonly IUserAccountService _accountService;
        private readonly IAppConfig _config;

        public AccountController(
            IUserAccountService accountService
            ,IAppConfig config)
        {
            _accountService = accountService;
            _config = config;
        }

        [SwaggerOperation(
            Summary = "Authenticates users and returns profile with claims",
            Description = "Anonymous privileges",
            OperationId = "CreateLogin",
            Tags = new[] { "Account" }
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<Models.UserAccount> Post(Login login)
        {

            if(null == login || string.IsNullOrWhiteSpace(login.Password) || string.IsNullOrWhiteSpace(login.Username))
            {
                return BadRequest("login model and all values must exist");
            }

            var modelUserAccount = _accountService
                .GetUserAccount(login.Username, login.Password);

            if(null == modelUserAccount)
            {
                return NotFound();
            }

            var viewModelUserAccount = modelUserAccount.Map();
            if (login.IsPersisted)
            {
                viewModelUserAccount.AppKeyExpirationUtc = DateTime.UtcNow.AddDays(_config.SessionPersistenceDays);
            }
            else
            {
                viewModelUserAccount.AppKeyExpirationUtc = DateTime.UtcNow.AddDays(2);
            }

            var serializedModelUserAccount = JsonConvert.SerializeObject(viewModelUserAccount);
            var encryptedSerialization = Cryptography.Cryptographer.Encrypt(serializedModelUserAccount);
            viewModelUserAccount.AppKey = encryptedSerialization; //encrypted token of claims and expiration


            return Ok(viewModelUserAccount);
        }
    }
}
