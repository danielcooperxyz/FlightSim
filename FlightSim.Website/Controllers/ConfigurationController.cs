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
    using FlightSim.Website.Models;
    using FlightSim.Framework.Entities;
    using System.Web.Script.Serialization;

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
            ConfigurationModel model = new ConfigurationModel();

            model.StoredConfigurations = this.configurationService.GetConfigurations();

            return this.View(model);
        }

        public string GetConfiguration(int configurationId)
        {
            Configuration requested = this.configurationService.Get(configurationId);

            if (requested == null)
            {
                return string.Empty;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(requested);
        }
    }
}
