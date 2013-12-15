﻿//-----------------------------------------------------------------------
// <copyright file="ExperimentController.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using FlightSim.Framework.Entities;
    using FlightSim.Framework.Services;
    using FlightSim.Website.Models;

    /// <summary>
    /// The experiment controller
    /// </summary>
    public class ExperimentController : Controller
    {
        private IExperimentService experimentService;

        public ExperimentController(IExperimentService experimentService)
        {
            if (experimentService == null)
            {
                throw new ArgumentNullException("Experiment Service");
            }

            this.experimentService = experimentService;
        }

        /// <summary>
        /// GET: /Experiment/
        /// </summary>
        /// <returns>The index view</returns>
        public ActionResult Index()
        {
            ExperimentModel model = new ExperimentModel();
            
            model.Experiment = this.experimentService.InitialiseExperiment();

            return this.View(model);
        }

        public void Save(float reationTime)
        {
 
        }
    }
}
