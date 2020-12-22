using afmr.api.Models;
using afmr.model.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace afmr.api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UserTokenHandler(
            this IApplicationBuilder app)
        { 
            app.Use(async (context, next) =>
            {
                //var logger = new Logger();

                var authKey = context
                    .Request
                    .Headers["Authorization"]
                    .FirstOrDefault(h => h.ToUpperInvariant().StartsWith("BEARER "));

                if (!string.IsNullOrWhiteSpace(authKey))
                {
                    var decryptedSerialization = Cryptography.Cryptographer.Decrypt(authKey.Substring(7));
                    
                    var userAccount = JsonConvert.DeserializeObject<UserAccount>(decryptedSerialization);

                    if (null == userAccount)
                    {
                        //TODO Log it, should never happen unless someone is trying to crack in              
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    }

                    if (userAccount.ExpiresOnUtc < DateTime.UtcNow)
                    {
                        //TODO _logger.LogInfo("");
                        context.Response.StatusCode = StatusCodes.Status419AuthenticationTimeout;
                    }
                    else if (userAccount.IsLockedOut)
                    {
                        //TODO _logger.LogInfo("");
                        context.Response.StatusCode = StatusCodes.Status423Locked;
                    }
                    else
                    {
                        var claimList = new List<Claim> {
                            new Claim(MarketResearchClaims.UserId, userAccount.UserAccountId.ToString(CultureInfo.InvariantCulture))
                           // new Claim(MarketResearchClaims.AppKey, authKey.Substring(7))
                        };

                        foreach (var item in userAccount.PermissionClaimValues)
                        {
                            claimList.Add(new Claim(item, string.Empty));
                        }

                        foreach (var item in userAccount.Orgs)
                        {
                            claimList.Add(new Claim(MarketResearchClaims.Orgs, item.Id.ToString()));
                        }

                        var claimsIdentity = new ClaimsIdentity(claimList, "custom");
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        context.User = claimsPrincipal;

                        // _logger.LogInformation("User - " + userAccountId + " access - " + context.Request.Path);
                    }
                }

                await next.Invoke();
            });
        }
    }
}
