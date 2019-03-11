using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShop.Models.Handler
{
    public class WashingtonianRequirement : AuthorizationHandler<WashingtonianHandler>, IAuthorizationRequirement
    { 
        /// <summary>
        /// Returns whether or not the task for our claim has been completed
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WashingtonianHandler requirement)
        {
            var state = context.User.Claims.First(c => c.Type == "State").Value;

            if (!context.User.HasClaim(c => c.Type == "State"))
            {
                return Task.CompletedTask;
            }


            else if (state == "true")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}