//-----------------------------------------------------------------------
// <copyright file="ExperimentService.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FlightSim.Framework.Entities;
    using FlightSim.Framework.Repositories;

    /// <summary>
    /// The experiment service
    /// </summary>
    public class ExperimentService : IExperimentService
    {
        /// <summary>
        /// The experiment repository implementation 
        /// </summary>
        private IExperimentRepository experimentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExperimentService"/> class
        /// </summary>
        /// <param name="experimentRepository">The experiment repository to use</param>
        public ExperimentService(IExperimentRepository experimentRepository)
        {
            if (experimentRepository == null)
            {
                throw new ArgumentNullException("Experiment Repository");
            }

            this.experimentRepository = experimentRepository;
        }

        /// <inheritdoc />
        public Experiment InitialiseExperiment()
        {
            Experiment newExperiment = new Experiment();

            newExperiment.GenerateTargetValues();

            this.Save(newExperiment);

            return newExperiment;
        }

        /// <inheritdoc />
        public Experiment Get(int id)
        {
            return this.experimentRepository.Get(id);
        }

        /// <inheritdoc />
        public void Save(Experiment experimentToSave)
        {
            this.experimentRepository.Save(experimentToSave);
        }
    }
}
