﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoffeeShop
{
    public class Program
    {
        /// <summary>
        /// access our seeded data
        /// </summary>
        /// <param name="args">  </param>
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                // get our service provider
                var services = scope.ServiceProvider;

                // call our seeded data (try/catch)
                try
                {
                    RoleInitializer.SeedData(services);
                }
                catch (Exception)
                {

                    // logging if needed
                }
            }

            host.Run();
        }

        /// <summary>
        /// fires web page
        /// </summary>
        /// <param name="args"></param>
        /// <returns> webpage </returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}