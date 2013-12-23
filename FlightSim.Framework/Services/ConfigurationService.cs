//-----------------------------------------------------------------------
// <copyright file="ConfigurationService.cs" Owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using System;
    using System.ComponentModel;
    using FlightSim.Framework.Entities;
    using FlightSim.Framework.Repositories;

    /// <summary>
    /// The configuration service
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// The configuration repository to use
        /// </summary>
        private IConfigurationRepository configurationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationService"/> class
        /// </summary>
        /// <param name="configurationRepository">The configuration repository to use</param>        
        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            if (configurationRepository == null)
            {
                this.configurationRepository = configurationRepository;
            }
        }

        /// <inheritdoc/>
        public Configuration GetActiveConfiguration()
        {
            return this.configurationRepository.GetActiveConfiguration();
        }

        /// <inheritdoc/>
        public void SaveNewActiveConfiguration(Configuration configuration)
        {
            Configuration oldActive = this.configurationRepository.GetActiveConfiguration();
            oldActive.Active = false;
            this.configurationRepository.Save(oldActive);

            if (configuration.Active == false)
            {
                configuration.Active = true;
            }

            this.configurationRepository.Save(configuration);
        }
    }
}
