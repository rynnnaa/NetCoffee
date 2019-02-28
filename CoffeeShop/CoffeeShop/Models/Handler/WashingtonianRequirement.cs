using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CoffeeShop.Models.Handler
{
    public class WashingtonianRequirement : AuthorizationHandler<WashingtonianRequirement>, IAuthorizationRequirement
    {
        private string _state;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="state"></param>
        public WashingtonianRequirement(string state)
        {
            _state = state;
        }
        /// <summary>
        /// Returns whether or not the task for our claim has been completed
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, WashingtonianRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.StateOrProvince))
            {
                return Task.CompletedTask;
            }

            var washington = context.User.FindFirst(c => c.Type == ClaimTypes.StateOrProvince).Value;

            if (washington == "Washington")
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}