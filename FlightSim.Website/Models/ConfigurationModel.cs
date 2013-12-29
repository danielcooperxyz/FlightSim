//-----------------------------------------------------------------------
// <copyright file="ConfigurationModel.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Models
{
    using System.Collections.Generic;
    using FlightSim.Framework.Entities;

    /// <summary>
    /// The configuration model
    /// </summary>
    public class ConfigurationModel
    {
        /// <summary>
        /// Stores the value for the selected configuration id
        /// </summary>
        private int configurationId;

        /// <summary>
        /// Stores the value for the current configuration
        /// </summary>;
        private Configuration configuration;

        /// <summary>
        /// Stores the value of all the stored configurations
        /// </summary>
        private IList<Configuration> storedConfigurations;

        /// <summary>
        /// Gets or sets the value of the configuration id to retrieve
        /// </summary>
        public int ConfigurationId
        {
            get
            {
                return this.configurationId;
            }

            set
            {
                this.configurationId = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for the current configuration
        /// </summary>
        public Configuration Configuration
        {
            get 
            {
                return this.configuration;
            }

            set
            {
                this.configuration = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for the stored configurations
        /// </summary>
        public IList<Configuration> StoredConfigurations
        {
            get
            {
                return this.storedConfigurations;
            }

            set
            {
                this.storedConfigurations = value;
            }
        }
    }
}