//-----------------------------------------------------------------------
// <copyright file="ConfigurationKey.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The possible configuration keys
    /// </summary>
    public enum ConfigurationKey
    {
        /// <summary>
        /// The configuration key for the atmospheric visibility
        /// </summary>
        AtmosphericVisibility,

        /// <summary>
        /// The configuration key for the real target size
        /// </summary>
        RealTargetSize,

        /// <summary>
        /// The configuration key for the initial target size
        /// </summary>
        InitialTargetSize,

        /// <summary>
        /// The configuration key for the user distance
        /// </summary>
        UserDistance,

        /// <summary>
        /// The configuration key to enable or disable moving targets
        /// </summary>
        MovingTargets
    }
}
