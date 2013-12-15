//-----------------------------------------------------------------------
// <copyright file="IExperimentRepository.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using FlightSim.Framework.Entities;

    /// <summary>
    /// The experiment repository interface
    /// </summary>
    public interface IExperimentRepository
    {
        /// <summary>
        /// Get the experiment for the given id
        /// </summary>
        /// <param name="id">The id of the experiment to get</param>
        /// <returns>The experiment object</returns>
        Experiment Get(Guid id);

        /// <summary>
        /// Save the experiment object
        /// </summary>
        /// <param name="experiment">The experiment object to save</param>
        void Save(Experiment experiment);
    }
}
