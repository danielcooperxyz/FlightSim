using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightSim.Website.Models
{
    public class ExperimentModel
    {
        /// <summary>
        /// Stores the value for the transparency constant
        /// </summary>
        private float transparencyConstant;
        
        /// <summary>
        /// Gets or sets the transparencyConstant
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
        /// Stores the value for the size constant
        /// </summary>
        private float sizeConstant;

        /// <summary>
        /// Gets or sets the sizeConstant
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
    }
}