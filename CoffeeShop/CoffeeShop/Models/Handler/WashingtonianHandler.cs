using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models.Handler
{
    public class WashingtonianHandler : IAuthorizationRequirement
    {
        public bool IState { get; set; }

        public WashingtonianHandler(bool iState)
        {
            IState = iState;
        }
    }
}
