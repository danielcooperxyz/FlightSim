//-----------------------------------------------------------------------
// <copyright file="ExperimentService.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using FlightSim.Framework.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IExperimentService
    {

        /// <summary>
        /// Create a new experiment to use on the website
        /// </summary>
        /// <returns>The new experiment object</returns>
        Experiment InitialiseExperiment();

    }
}
