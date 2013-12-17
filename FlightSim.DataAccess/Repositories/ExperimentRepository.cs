//-----------------------------------------------------------------------
// <copyright file="ExperimentRepository.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace FlightSim.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FlightSim.Framework.Entities;
    using FlightSim.Framework.Repositories;
    using NHibernate;

    /// <summary>
    /// The experiment repository
    /// </summary>
    public class ExperimentRepository : IExperimentRepository
    {
        /// <summary>
        /// The session object
        /// </summary>
        private ISession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExperimentRepository"/> class
        /// </summary>
        /// <param name="session">The session to use</param>
        public ExperimentRepository(ISession session) 
        {
            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            this.session = session;
        }

        /// <summary>
        /// Get the experiment for the given id
        /// </summary>
        /// <param name="id">The id of the experiment to get</param>
        /// <returns>The experiment object</returns>
        public Experiment Get(Guid id)
        {
            return this.session.QueryOver<Experiment>()
                .Where(e => e.Id == id)
                .List().FirstOrDefault();
        }

        /// <summary>
        /// Save the experiment object
        /// </summary>
        /// <param name="experiment">The experiment object to save</param>
        public void Save(Experiment experiment)
        {
            this.session.Save(experiment);
        }
    }
}
