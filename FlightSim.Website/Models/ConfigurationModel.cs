//-----------------------------------------------------------------------
// <copyright file="ConfigurationModel.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Models
{
    using FlightSim.Framework.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The configuration model
    /// </summary>
    public class ConfigurationModel
    {
        /// <summary>
        /// Stores the value for the current configuration
        /// </summary>
        private Configuration config;

        /// <summary>
        /// Gets or sets the value for the current configuration
        /// </summary>
        public Configuration Configuration
        {
            get 
            {
                return this.config;
            }

            set
            {
                this.config = value;
            }
        }
    }
}