//-----------------------------------------------------------------------
// <copyright file="ConfigurationRepository.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using FlightSim.Framework.Entities;
    using FlightSim.Framework.Repositories;
    using NHibernate;

    /// <summary>
    /// The configuration repository implementation
    /// </summary>
    public class ConfigurationRepository : IConfigurationRepository
    {
        /// <summary>
        /// The session to use
        /// </summary>
        private ISession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationRepository"/> class
        /// </summary>
        /// <param name="session">The session to use</param>
        public ConfigurationRepository(ISession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException("Session");
            }

            this.session = session;
        }

        /// <inheritdoc />
        public Configuration Get(int id)
        {
            return this.session.QueryOver<Configuration>()
                .Where(c => c.Id == id)
                .SingleOrDefault<Configuration>();
        }

        /// <inheritdoc />
        public IList<Configuration> GetConfigurations()
        {
            return this.session.QueryOver<Configuration>()
                .Where(c => c.Deleted == false)
                .List();
        }

        /// <inheritdoc />
        public Configuration GetActiveConfiguration()
        {
            return this.session.QueryOver<Configuration>()
                .Where(c => c.Active == true && c.Deleted == false)
                .SingleOrDefault<Configuration>();
        }

        /// <inheritdoc />
        public void Save(Configuration configuration)
        {
            this.session.Save(configuration);
            this.session.Flush();
        }
    }
}
