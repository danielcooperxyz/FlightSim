//-----------------------------------------------------------------------
// <copyright file="IExperimentService.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using System;
    using FlightSim.Framework.Entities;

    /// <summary>
    /// The experiment service interface
    /// </summary>
    public interface IExperimentService
    {
        /// <summary>
        /// Create a new experiment to use on the website
        /// </summary>
        /// <returns>The new experiment object</returns>
        Experiment InitialiseExperiment();
        
        /// <summary>
        /// Get an experiment with passed if
        /// </summary>
        /// <param name="id">The id of the experiment to get</param>
        /// <returns>The experiment with the matching id</returns>
        Experiment Get(int id);

        /// <summary>
        /// Save the passed the experiment
        /// </summary>
        /// <param name="experimentToSave">The experiment object to save</param>
        void Save(Experiment experimentToSave);
    }
}
