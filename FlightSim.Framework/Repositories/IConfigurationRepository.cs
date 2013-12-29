﻿//-----------------------------------------------------------------------
// <copyright file="IConfigurationRepository.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Repositories
{
    using System.Collections.Generic;
    using FlightSim.Framework.Entities;

    /// <summary>
    /// The configuration repository interface
    /// </summary>
    public interface IConfigurationRepository
    {
        /// <summary>
        /// Get the configuration for the id passed
        /// </summary>
        /// <param name="id">The id of the configuration to get</param>
        /// <returns>The configuration</returns>
        Configuration Get(int id);

        /// <summary>
        /// Get the stored configurations that aren't deleted.
        /// </summary>
        /// <returns>All of the configurations that aren't marked as deleted</returns>
        IList<Configuration> GetConfigurations();

        /// <summary>
        /// Get the currently active configuration
        /// </summary>
        /// <returns>The active configuration</returns>
        Configuration GetActiveConfiguration();
        
        /// <summary>
        /// Save the passed configuration
        /// </summary>
        /// <param name="configuration">The configuration to save</param>
        void Save(Configuration configuration);
    }
}