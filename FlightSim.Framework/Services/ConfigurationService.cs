//-----------------------------------------------------------------------
// <copyright file="ConfigurationService.cs" Owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using System;
    using System.Collections.Generic;
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
                throw new ArgumentNullException("Configuration Repository");
            }

            this.configurationRepository = configurationRepository;
        }

        /// <inheritdoc />
        public Configuration Get(int configurationId)
        {
            return this.configurationRepository.Get(configurationId);
        }

        /// <inheritdoc />
        public IList<Configuration> GetConfigurations()
        {
            return this.configurationRepository.GetConfigurations();
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
