//-----------------------------------------------------------------------
// <copyright file="Experiment.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Entities
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The experiment class
    /// </summary>
    public class Experiment
    {
        /// <summary>
        /// Stores the id of the experiment
        /// </summary>
        private Guid id;

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
        private List<float> targetRadiuses;

        /// <summary>
        /// Stores the values to use for the target opacities
        /// </summary>
        private List<float> targetOpacities;

        /// <summary>
        /// Stores the value to use for the x position of the target
        /// </summary>
        private int x_Position;

        /// <summary>
        /// Stores the value to use for the y position of the target
        /// </summary>
        private int y_Position;

        /// <summary>
        /// Stores the value to determine whether the target should move or not
        /// </summary>
        private bool movingTarget;

        /// <summary>
        /// Stores the value for the user's reaction time
        /// </summary>
        private float reactionTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Experiment"/> class
        /// </summary>
        public Experiment()
        {

        }

        /// <summary>
        /// Gets or sets the value for the experiment id
        /// </summary>
        public Guid Id
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
        public List<float> TargetRadiuses
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
        public List<float> TargetOpacities
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

        /// <summary>
        /// Gets or sets the x position value
        /// </summary>
        public int XPosition
        {
            get
            {
                return this.x_Position;
            }

            set
            {
                this.x_Position = value;
            }
        }

        /// <summary>
        /// Gets or sets the y position value
        /// </summary>
        public int YPosition
        {
            get
            {
                return this.y_Position;
            }

            set
            {
                this.y_Position = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for moving target
        /// </summary>
        public bool MovingTarget
        {
            get
            {
                return this.movingTarget;
            }

            set
            {
                this.movingTarget = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for the user's reaction time
        /// </summary>
        public float ReactionTime
        {
            get
            {
                return this.reactionTime;
            }

            set
            {
                this.reactionTime = value;
            }
        }

        /// <summary>
        /// Generate a new radius based on the time passed
        /// </summary>
        /// <param name="time">The time value</param>
        /// <returns>The generated radius</returns>
        public float GenerateRadius(int time)
        {
            // Radius = (b * x_0/(R - (v *t)))
            return ((this.realTargetSize * this.userDistance) / (this.atmosphericVisibility - (this.closingSpeed * time)));
        }

        /// <summary>
        /// Generate a new opacity based on the new radius and time passed.
        /// </summary>
        /// <param name="radius">The new radius</param>
        /// <param name="time">The time value</param>
        /// <returns>The generated opacity</returns>
        public float GenerateOpacity(float radius, int time)
        {
            // TRANSPARENCY =1-(e^(-2.996 * (r_0 / r)))
            return Convert.ToSingle(1 - (Math.Exp(-2.996 * (this.initialTargetSize / radius))));
        }
    }
}
