//-----------------------------------------------------------------------
// <copyright file="ExperimentModel.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Models
{
    using FlightSim.Framework.Entities;

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
        /// Gets or sets the experiment object
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