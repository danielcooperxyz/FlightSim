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
        /// <param name="id">The id of the experiment to save the details to</param>
        /// <param name="xPostion">The x position to save</param>
        /// <param name="yPostion">The y position to save</param>
        /// <param name="reactionTime">The reaction time to save</param>
        public void Save(Guid id, float xPostion, float yPostion, float reactionTime)
        {
            Experiment expToUpdate = this.experimentService.Get(id);

            expToUpdate.XPosition = xPostion;
            expToUpdate.YPosition = yPostion;
            expToUpdate.ReactionTime = reactionTime;

            this.experimentService.Save(expToUpdate);
        }
    }
}
