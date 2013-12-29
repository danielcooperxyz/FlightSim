//-----------------------------------------------------------------------
// <copyright file="Experiment.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Framework.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// The experiment class
    /// </summary>
    public class Experiment
    {
        /// <summary>
        /// Stores the id of the experiment
        /// </summary>
        private int id;

        /// <summary>
        /// Stores the values to use for the calculated radiuses
        /// </summary>
        private List<double> calculatedRadiuses;

        /// <summary>
        /// Stores the values to use for the calculated opacities
        /// </summary>
        private List<double> calculatedOpacities;

        /// <summary>
        /// Stores the value to use for the x position of the target
        /// </summary>
        private double xPosition;

        /// <summary>
        /// Stores the value to use for the y position of the target
        /// </summary>
        private double yPosition;

        /// <summary>
        /// Stores the value for the reaction time of the experiment participant
        /// </summary>
        private double reactionTime;

        /// <summary>
        /// Stores the rounded values for the radius and the number of seconds to animate between
        /// </summary>
        private List<KeyValuePair<int, int>> roundedRadiuses;

        /// <summary>
        /// Stores the values to use for the target opacities
        /// </summary>
        private List<double> targetOpacities;

        /// <summary>
        /// Stores the value for the start time of the experiment
        /// </summary>
        private double startTime;

        /// <summary>
        /// Stores the value for the end time of the experiment
        /// </summary>
        private double endTime;

        /// <summary>
        /// Stores the configuration for the experiment
        /// </summary>
        private Configuration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Experiment"/> class
        /// </summary>
        public Experiment()
        { 
        }

        /// <summary>
        /// Gets or sets the value for the experiment id
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
        /// Gets or sets the calculated radiuses
        /// </summary>
        public virtual List<double> CalculatedRadiuses
        {
            get
            {
                return this.calculatedRadiuses;
            }

            set
            {
                this.calculatedRadiuses = value;
            }
        }

        /// <summary>
        /// Gets or sets the target opacities
        /// </summary>
        public virtual List<double> CalculatedOpacities
        {
            get
            {
                return this.calculatedOpacities;
            }

            set
            {
                this.calculatedOpacities = value;
            }
        }

        /// <summary>
        /// Gets or sets the x position value
        /// </summary>
        public virtual double XPosition
        {
            get
            {
                return this.xPosition;
            }

            set
            {
                this.xPosition = value;
            }
        }

        /// <summary>
        /// Gets or sets the y position value
        /// </summary>
        public virtual double YPosition
        {
            get
            {
                return this.yPosition;
            }

            set
            {
                this.yPosition = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for the user's reaction time
        /// </summary>
        public virtual double ReactionTime
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
        /// Gets or sets the configuration for this experiment
        /// </summary>
        public virtual Configuration Configuration
        {
            get
            {
                return this.configuration;
            }

            set
            {
                this.configuration = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for the rounded radiuses
        /// </summary>
        public virtual List<KeyValuePair<int, int>> RoundedRadiuses
        {
            get
            {
                return this.roundedRadiuses;
            }

            set
            {
                this.roundedRadiuses = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for the target opacities
        /// </summary>
        public virtual List<double> TargetOpacities
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
        /// Gets or sets the value for start time of the experiment
        /// </summary>
        public virtual double StartTime
        {
            get
            {
                return this.startTime;
            }

            set
            {
                this.startTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the value for end time of the experiment
        /// </summary>
        public virtual double EndTime
        {
            get
            {
                return this.endTime;
            }

            set
            {
                this.endTime = value;
            }
        }

        /// <summary>
        /// Generate the values to use for the target on screen
        /// </summary>
        public virtual void GenerateTargetValues()
        {
            double radius = 0;
            double opacity = 0;
            int time = 0;

            int roundedRadius = 0;
            int tempRounded = 0;

            this.CalculatedRadiuses = new List<double>();
            this.CalculatedOpacities = new List<double>();
            this.TargetOpacities = new List<double>();
            this.RoundedRadiuses = new List<KeyValuePair<int, int>>();

            while (radius >= 0)
            {
                radius = this.GenerateRadii(time);
                opacity = this.GenerateOpacity(radius, time);

                this.calculatedRadiuses.Add(radius);
                this.calculatedOpacities.Add(opacity);

                try
                {
                    tempRounded = Convert.ToInt32(Math.Round(radius, 1, MidpointRounding.AwayFromZero));

                    if (tempRounded > roundedRadius)
                    {
                        roundedRadius = tempRounded;

                        this.roundedRadiuses.Add(new KeyValuePair<int, int>(roundedRadius, time));
                        this.targetOpacities.Add(opacity);

                        // time = -1;
                    }
                }
                catch (OverflowException ex)
                {
                    // Should replace this, not sure how to evaluate infinity.
                    Debug.Write("Infinity reached - " + ex.Message);
                }

                time++;
            }
        }

        /// <summary>
        /// Generate a new radius based on the time passed
        /// </summary>
        /// <param name="time">The time value</param>
        /// <returns>The generated radius</returns>
        private double GenerateRadii(int time)
        {
            // Radius = (b * x_0/(R - (v *t)))
            double targetDistance = this.Configuration.AtmosphericVisibility - (this.Configuration.ClosingSpeed * time);

            double perspective = this.Configuration.RealTargetSize * this.Configuration.UserDistance;

            double radius = perspective / targetDistance;

            return radius * 100;
        }

        /// <summary>
        /// Generate a new opacity based on the new radius and time passed.
        /// </summary>
        /// <param name="radius">The new radius</param>
        /// <param name="time">The time value</param>
        /// <returns>The generated opacity</returns>
        private double GenerateOpacity(double radius, int time)
        {
            // TRANSPARENCY =1-(e^(-2.996 * (r_0 / r)))
            double opacity = Math.Exp(-2.996 * this.Configuration.InitialTargetSize / radius);

            return opacity;
        }
    }
}
