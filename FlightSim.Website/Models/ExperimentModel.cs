//-----------------------------------------------------------------------
// <copyright file="ExperimentModel.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Models
{
    using FlightSim.Framework.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The experiment model
    /// </summary>
    public class ExperimentModel
    {
        /// <summary>
        /// The experiment object
        /// </summary>
        private Experiment experiment;

        /// <summary>
        /// Get or set the experiment object
        /// </summary>
        public Experiment Experiment
        {
            get
            {
                return this.experiment;
            }

            set
            {
                this.experiment = value;
            }
        }
    }
}