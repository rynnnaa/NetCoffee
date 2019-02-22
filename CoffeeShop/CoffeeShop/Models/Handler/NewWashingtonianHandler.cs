using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Handler
{
    public class NewWashingtonianHandler : AuthorizationHandler<WashingtonianRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WashingtonianRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.StateOrProvince))
            {
                return Task.CompletedTask();
            }

            var washington = context.User.FindFirst(c => c.Type == ClaimTypes.StateOrProvince).Value;



            if (washington != "Washington")
            {

            }
            if (washington == "Washington")
            {
                context.Succeed(requirement);
            }



            return Task.CompletedTask;
        }


    }
}
