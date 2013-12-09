//-----------------------------------------------------------------------
// <copyright file="ExperimentService.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            return new Experiment();
        }
    }
}
