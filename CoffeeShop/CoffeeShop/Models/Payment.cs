using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Payment
    {
        private IConfiguration _configuration;
        public Payment(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// creating merchant info
        /// </summary>
        /// <returns> TBD </returns>
        public string Run()
        {
            // declare that we are using the Sandbox account. 

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // set merchant info
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = "28mJ9dEu",
                ItemElementName = ItemChoiceType.transactionKey,
                Item = "7mH28243jP3wN8w7"
            };

            // Create CC.

            var creditCard = new creditCardType
            {
                cardNumber = "4111111111111111",
                expirationDate = "1120"
            };

            customerAddressType billingAddress = GetAddress();
            return " it works";
        }
        /// <summary>
        /// address of user
        /// bring in user as parameter
        /// bring in user id? ...maybe...
        /// </summary>
        /// <returns> address</returns>
        private customerAddressType GetAddress()
        {
           
            customerAddressType address = new customerAddressType()
            {

                firstName = "Donkey",
                lastName = "Kong",
                address = "123 Donkey lane",
                city = "New York",
                zip = "08069"
            };
            return address;
        }

    }
}

