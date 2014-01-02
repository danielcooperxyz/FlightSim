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
        public ActionResult Index(ConfigurationModel model = null)
        {
            if (model == null)
            {
                model = new ConfigurationModel();
            }

            model.StoredConfigurations = this.configurationService.GetConfigurations();

            return this.View(model);
        }

        /// <summary>
        /// GET: /Configuration/SaveConfiguration
        /// </summary>
        /// <param name="model">The configuration model</param>
        /// <returns></returns>
        public ActionResult Save(ConfigurationModel model)
        {
            ModelState.Clear();

            if (model != null)
            {
                if (model.Configuration != null)
                {
                    if (model.Configuration.Name != null)
                    {
                        if (model.Configuration.Id == 0)
                        {
                            this.configurationService.Create(model.Configuration);
                        }
                        else
                        {
                            if (model.Configuration.Active)
                            {
                                this.configurationService.SaveNewActiveConfiguration(model.Configuration);
                            }
                            else
                            {
                                this.configurationService.Update(model.Configuration);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ConfigurationName", "You must enter a name for the configuration.");
                        model.StoredConfigurations = this.configurationService.GetConfigurations();
                        return this.View("Index", model);
                    }
                }
            }

            return this.RedirectToAction("Index", "Configuration", model);
        }

        /// <summary>
        /// GET: /Configuration/GetConfiguration?id=0
        /// </summary>
        /// <param name="configurationId">The id of the configuration to get</param>
        /// <returns>The configuration object serialized to JSON</returns>
        public string GetConfiguration(int configurationId)
        {
            Configuration requested = this.configurationService.Get(configurationId);

            if (requested == null)
            {
                return string.Empty;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(requested);
        }

        /// <summary>
        ///  POST: /Configuration/ActivateConfiguration?id=0
        /// </summary>
        /// <param name="configurationId">The id of the configuration to activate</param>
        public void ActivateConfiguration(int configurationId)
        {
            this.configurationService.ActivateConfiguration(configurationId);
        }

        /// <summary>
        ///  POST: /Configuration/DeleteConfiguration?id=0
        /// </summary>
        /// <param name="configurationId">The id of the configuration to activate</param>
        public void DeleteConfiguration(int configurationId)
        {
            this.configurationService.DeleteConfiguration(configurationId);
        }
    }
}
