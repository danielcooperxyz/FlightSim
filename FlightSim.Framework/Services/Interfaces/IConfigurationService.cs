//-----------------------------------------------------------------------
// <copyright file="IConfigurationService.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using System.Collections.Generic;
    using FlightSim.Framework.Entities;

    /// <summary>
    /// The configuration service interface
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Get the configuration that matches the passed id
        /// </summary>
        /// <param name="configurationId">The id of the configuration to retrieve</param>
        /// <returns>The requested id</returns>
        Configuration Get(int configurationId);

        /// <summary>
        /// Get all the stored configurations
        /// </summary>
        /// <returns>All the stored configurations that aren't marked as deleted</returns>
        IList<Configuration> GetConfigurations();

        /// <summary>
        /// Get the currently active configuration
        /// </summary>
        /// <returns>The active configuration</returns>
        Configuration GetActiveConfiguration();

        /// <summary>
        /// Saves a new currently active configuration
        /// </summary>
        /// <param name="activeConfiguration">The newly active configuration</param>
        void SaveNewActiveConfiguration(Configuration activeConfiguration);
    }
}
