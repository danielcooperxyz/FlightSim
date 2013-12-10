//-----------------------------------------------------------------------
// <copyright file="ExperimentService.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FlightSim.Framework.Entities;

    /// <summary>
    /// The experiment service
    /// </summary>
    public class ExperimentService
    {
        /// <summary>
        /// Create a new experiment to use on the website
        /// </summary>
        /// <returns>The new experiment object</returns>
        public static Experiment CreateExperiment()
        {
            Experiment newExperiment = new Experiment();

            newExperiment.AtmosphericVisibilty = ConfigurationService.GetConfigurationValue<int>(ConfigurationKey.AtmosphericVisibility.ToString());

            return newExperiment;
        }
    }
}
