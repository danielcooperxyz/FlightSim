//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Entities
{
    /// <summary>
    /// The possible configuration keys
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// The value of the id of the configuration
        /// </summary>
        private int id;

        /// <summary>
        /// The value for the atmospheric visibility
        /// </summary>
        private int atmosphericVisibility;

        /// <summary>
        /// The value for the real target size
        /// </summary>
        private int realTargetSize;

        /// <summary>
        /// The value for the initial target size
        /// </summary>
        private float initialTargetSize;

        /// <summary>
        /// The value for the user distance
        /// </summary>
        private int userDistance;

        /// <summary>
        /// The value for the closing speed of the target
        /// </summary>
        private int closingSpeed;

        /// <summary>
        /// The value enable or disable moving targets
        /// </summary>
        private bool movingTargets;

        /// <summary>
        /// The value to set this configuration as active or not
        /// </summary>
        private bool active;

        /// <summary>
        /// The value to set this configuration as deleted or not
        /// </summary>
        private bool deleted;

        /// <summary>
        /// Gets or sets the id of this configuration
        /// </summary>
        public virtual int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for the atmospheric visibility
        /// </summary>
        public virtual int AtmosphericVisibility
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
        /// Gets or sets the value for the user distance
        /// </summary>
        public virtual int UserDistance
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
        /// Gets or sets the value for the closing speed
        /// </summary>
        public virtual int ClosingSpeed
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
        /// Gets or sets the value for the initial target size
        /// </summary>
        public virtual float InitialTargetSize
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
        /// Gets or sets the value for the real target size
        /// </summary>
        public virtual int RealTargetSize
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
        /// Gets or sets a value indicating whether the experiment targets move or not
        /// </summary>
        public virtual bool MovingTargets
        {
            get
            {
                return this.movingTargets;
            }

            set
            {
                this.movingTargets = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the experiment is active or not
        /// </summary>
        public virtual bool Active
        {
            get
            {
                return this.active;
            }

            set
            {
                this.active = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether an experiment is deleted or not
        /// </summary>
        public virtual bool Deleted
        {
            get
            {
                return this.deleted;
            }

            set
            {
                this.deleted = value;
            }
        }
    }
}
