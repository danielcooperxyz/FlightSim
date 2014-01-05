//-----------------------------------------------------------------------
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
        /// <summary>
        /// The experiment service to use
        /// </summary>
        private IExperimentService experimentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExperimentController"/> class
        /// </summary>
        /// <param name="experimentService">The experiment service</param>
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

        /// <summary>
        /// POST: /Experiment/Save
        /// </summary>
        /// <param name="model">The experiment model which stores the experiment values to save</param>
        /// <returns>The Save view</returns>
        public ActionResult Save(ExperimentModel model)
        {
            Experiment expToUpdate = this.experimentService.Get(model.Experiment.Id);

            expToUpdate.XPosition = model.Experiment.XPosition;
            expToUpdate.YPosition = model.Experiment.YPosition;
            expToUpdate.StartTime = model.Experiment.StartTime;
            expToUpdate.EndTime = model.Experiment.EndTime;
            expToUpdate.ReactionTime = model.Experiment.EndTime - model.Experiment.StartTime;
            expToUpdate.EndDiameter = model.Experiment.EndDiameter;
            expToUpdate.EndOpacity = model.Experiment.EndOpacity;

            this.experimentService.Save(expToUpdate);

            model.Experiment = expToUpdate;

            return this.View(model);
        }
    }
}