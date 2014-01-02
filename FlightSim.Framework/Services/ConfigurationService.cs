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
    using System.Linq;
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
        public void Create(Configuration configurationToCreate)
        {
            this.configurationRepository.Create(configurationToCreate);
        }

        /// <inheritdoc />
        public void Update(Configuration configurationToSave)
        {
            this.configurationRepository.Update(configurationToSave);
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
            
            if (oldActive != null)
            {
                oldActive.Active = false;
                this.configurationRepository.Update(oldActive);
            }

            if (configuration.Active == false)
            {
                configuration.Active = true;
            }

            this.configurationRepository.Update(configuration);
        }
        
        /// <inheritdoc/>
        public void ActivateConfiguration(int configurationId)
        {
            Configuration toActivate = this.Get(configurationId);

            this.SaveNewActiveConfiguration(toActivate);
        }

        /// <inheritdoc/>
        public void DeleteConfiguration(int configurationId)
        {
            Configuration toDelete = this.Get(configurationId);

            if (toDelete.Active)
            {
                Configuration newActive = this.configurationRepository.GetConfigurations().FirstOrDefault();

                if (newActive != null)
                {
                    this.SaveNewActiveConfiguration(newActive);
                }
            }

            toDelete.Deleted = true;

            this.configurationRepository.Update(toDelete);            
        }
    }
}
