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

    /// <summary>
    /// The experiment service
    /// </summary>
    public class ExperimentService
    {
        //private ExperimentRepository experimentRepository;
        /// <summary>
        /// Create a new experiment to use on the website
        /// </summary>
        /// <returns>The new experiment object</returns>
        public static Experiment InitialiseExperiment()
        {
            Experiment newExperiment = new Experiment();

            newExperiment.AtmosphericVisibilty = ConfigurationService.GetConfigurationValue<int>(ConfigurationKey.AtmosphericVisibility);
            newExperiment.UserDistance = ConfigurationService.GetConfigurationValue<int>(ConfigurationKey.UserDistance);
            newExperiment.InitialTargetSize = ConfigurationService.GetConfigurationValue<int>(ConfigurationKey.InitialTargetSize);
            newExperiment.RealTargetSize = ConfigurationService.GetConfigurationValue<int>(ConfigurationKey.RealTargetSize);
            newExperiment.ClosingSpeed = ConfigurationService.GetConfigurationValue<int>(ConfigurationKey.ClosingSpeed);

            newExperiment.MovingTarget = ConfigurationService.GetConfigurationValue<bool>(ConfigurationKey.MovingTargets);

            for (int i = 0; i < 30; i++)
            {
                newExperiment.TargetRadiuses.Add(newExperiment.GenerateRadius(i));

                newExperiment.TargetOpacities.Add(newExperiment.GenerateOpacity(newExperiment.TargetRadiuses[i], i));
            }

            return newExperiment;
        }
    }
}
