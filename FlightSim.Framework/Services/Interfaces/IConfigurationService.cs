//-----------------------------------------------------------------------
// <copyright file="IConfigurationService.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using FlightSim.Framework.Entities;

    /// <summary>
    /// The configuration service interface
    /// </summary>
    public interface IConfigurationService
    {
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
