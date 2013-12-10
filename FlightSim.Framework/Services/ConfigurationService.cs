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
    using System.Configuration;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The configuration service
    /// </summary>
    public class ConfigurationService
    {
        /// <summary>
        /// Get and parse configuration value from configuration file
        /// </summary>
        /// <typeparam name="T">The type to parse the configuration value to</typeparam>
        /// <param name="configKey">The configuration key for the value</param>
        /// <param name="defaultValue">The default value to return</param>
        /// <returns>The parsed configuration value</returns>
        public static T GetConfigurationValue<T>(string configKey, T defaultValue = default(T)) where T : IConvertible
        {
            if (string.IsNullOrEmpty(configKey))
            {
                throw new ConfigurationErrorsException();
            }

            string configValue = ConfigurationManager.AppSettings[configKey];

            var converter = TypeDescriptor.GetConverter(typeof(T));

            try
            {
                return (T)converter.ConvertFromString(configValue);
            }
            catch (Exception)
            {
                throw new ConfigurationErrorsException();
            }
        }
    }
}
