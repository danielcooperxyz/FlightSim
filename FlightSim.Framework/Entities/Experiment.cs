//-----------------------------------------------------------------------
// <copyright file="Experiment.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Entities
{
    using System;

    /// <summary>
    /// The experiment class
    /// </summary>
    public class Experiment
    {
        /// <summary>
        /// Stores the value for atmospheric visibility
        /// </summary>
        private int atmosphericVisibility;

        /// <summary>
        /// Stores the value for user distance
        /// </summary>
        private int userDistance;

        /// <summary>
        /// Stores the value for closing speed
        /// </summary>
        private int closingSpeed;

        /// <summary>
        /// Stores the value for initial target size
        /// </summary>
        private float initialTargetSize;

        /// <summary>
        /// Stores the value for real target size
        /// </summary>
        private int realTargetSize;

        /// <summary>
        /// Stores the values to use for the target radiuses
        /// </summary>
        private float[] targetRadiuses;

        /// <summary>
        /// Stores the values to use for the target opacities
        /// </summary>
        private float[] targetOpacities;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Experiment"/> class
        /// </summary>
        public Experiment()
        {
        }

        /// <summary>
        /// Gets or sets the value for atmospheric visibility
        /// </summary>
        public int AtmosphericVisibilty
        {
            get
            {
                return this.atmosphericVisibility;
            }

            set
            {
                this.atmosphericVisibility = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for user distance
        /// </summary>
        public int UserDistance
        {
            get
            {
                return this.userDistance;
            }

            set
            {
                this.userDistance = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for closing speed
        /// </summary>
        public int ClosingSpeed
        {
            get
            {
                return this.closingSpeed;
            }

            set
            {
                this.closingSpeed = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for initial target size
        /// </summary>
        public float InitialTargetSize
        {
            get
            {
                return this.initialTargetSize;
            }

            set
            {
                this.initialTargetSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the real target size
        /// </summary>
        public int RealTargetSize
        {
            get
            {
                return this.realTargetSize;
            }

            set
            {
                this.realTargetSize = value;
            }
        }
        
        /// <summary>
        /// Gets or sets the target radiuses
        /// </summary>
        public float[] TargetRadiuses
        {
            get
            {
                return this.targetRadiuses;
            }

            set
            {
                this.targetRadiuses = value;
            }
        }

        /// <summary>
        /// Gets or sets the target opacities
        /// </summary>
        public float[] TargetOpacities
        {
            get
            {
                return this.targetOpacities;
            }

            set
            {
                this.targetOpacities = value;
            }
        }
    }
}
