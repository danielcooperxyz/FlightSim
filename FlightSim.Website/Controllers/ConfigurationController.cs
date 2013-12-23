//-----------------------------------------------------------------------
// <copyright file="ConfigurationController.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Controllers
{
    using System;
    using System.Web.Mvc;
    using FlightSim.Framework.Services;

    /// <summary>
    /// The configuration controller
    /// </summary>
    public class ConfigurationController : Controller
    {
        /// <summary>
        /// The configuration service to use
        /// </summary>
        private IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationController"/> class
        /// </summary>
        /// <param name="configurationService">The configuration service to use</param>
        public ConfigurationController(IConfigurationService configurationService)
        {
            if (configurationService == null)
            {
                throw new ArgumentNullException("Configuration Service");
            }

            this.configurationService = configurationService;                 
        }

        /// <summary>
        /// GET: /Configuration/
        /// </summary>
        /// <returns>The Index view</returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
