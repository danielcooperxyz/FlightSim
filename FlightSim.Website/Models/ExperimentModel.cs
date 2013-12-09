//-----------------------------------------------------------------------
// <copyright file="ExperimentModel.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.Website.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The experiment model
    /// </summary>
    public class ExperimentModel
    {
        /// <summary>
        /// Stores the value for the transparency constant
        /// </summary>
        private float transparencyConstant;

        /// <summary>
        /// Stores the value for the size constant
        /// </summary>
        private float sizeConstant;

        /// <summary>
        /// Stores the value for the initial radius
        /// </summary>
        private float initialRadius;

        /// <summary>
        /// Stores the value for the atmospheric visibility
        /// </summary>
        private int atmosphericVisibility;

        /// <summary>
        /// Stores the value for the user distance
        /// </summary>
        private int userDistance;

        /// <summary>
        /// Stores the value for the real target size
        /// </summary>
        private int realTargetSize;

        /// <summary>
        /// Gets or sets the size constant
        /// </summary>
        public float SizeConstant
        {
            get
            {
                return this.sizeConstant;
            }

            set
            {
                this.sizeConstant = value;
            }
        }

        /// <summary>
        /// Gets or sets the transparency constant
        /// </summary>
        public float TransparencyConstant
        {
            get
            {
                return this.transparencyConstant;
            }

            set
            {
                this.transparencyConstant = value;
            }
        }

        /// <summary>
        /// Gets or sets the atmospheric visibility
        /// </summary>
        public int AtmosphericVisibility
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
        /// Gets or sets the initial radius
        /// </summary>
        public float InitialRadius
        {
            get
            {
                return this.initialRadius;
            }

            set
            {
                this.initialRadius = value;
            }
        }

        /// <summary>
        /// Gets or sets the user distance
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
    }
}