//-----------------------------------------------------------------------
// <copyright file="ExperimentMap.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.DataAccess.Mappings
{
    using FlightSim.Framework.Entities;
    using NHibernate.Mapping.ByCode.Conformist;
    using NHibernate.Type;

    /// <summary>
    /// The database map for the experiment
    /// </summary>
    public class ExperimentMap : ClassMapping<Experiment>
    {
        /// <summary>
        /// Initializes a new instance of the ExperimentMap class
        /// </summary>
        public ExperimentMap()
        {
            this.Table("Experiment");

            this.Id(e => e.Id);

            this.Property(e => e.AtmosphericVisibility, m => { m.Type<Int32Type>(); });
            this.Property(e => e.UserDistance, m => { m.Type<Int32Type>(); });
            this.Property(e => e.ClosingSpeed, m => { m.Type<Int32Type>(); });
            this.Property(e => e.InitialTargetSize, m => { m.Type<DoubleType>(); });
            this.Property(e => e.RealTargetSize, m => { m.Type<Int32Type>(); });
            this.Property(e => e.XPosition, m => { m.Type<DoubleType>(); });
            this.Property(e => e.YPosition, m => { m.Type<DoubleType>(); });
            this.Property(e => e.MovingTargets, m => { m.Type<BooleanType>(); });
            this.Property(e => e.ReactionTime, m => { m.Type<DoubleType>(); });
            this.Property(e => e.StartTime, m => { m.Type<DoubleType>(); });
            this.Property(e => e.EndTime, m => { m.Type<DoubleType>(); });
        }
    }
}
