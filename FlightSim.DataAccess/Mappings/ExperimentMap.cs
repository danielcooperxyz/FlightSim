//-----------------------------------------------------------------------
// <copyright file="ExperimentMap.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.DataAccess.Mappings
{
    using FlightSim.Framework.Entities;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Mapping.ByCode.Conformist;
    using NHibernate.Type;

    /// <summary>
    /// The database map for the experiment
    /// </summary>
    public class ExperimentMap : ClassMapping<Experiment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExperimentMap"/> class
        /// </summary>
        public ExperimentMap()
        {
            this.Table("Experiment");

            this.Id(e => e.Id, m => { m.Generator(Generators.Identity); });

            this.Property(e => e.XPosition, m => { m.Type<DoubleType>(); });
            this.Property(e => e.YPosition, m => { m.Type<DoubleType>(); });
            this.Property(e => e.ReactionTime, m => { m.Type<DoubleType>(); });
            this.Property(e => e.StartTime, m => { m.Type<DoubleType>(); });
            this.Property(e => e.EndTime, m => { m.Type<DoubleType>(); });

            this.ManyToOne(
            e => e.Configuration,
            c =>
            {
                c.Cascade(Cascade.All);
                c.Column("ConfigurationId");
                c.ForeignKey("FK_Experiment_Configuration");
                c.Class(typeof(Configuration));
            });
        }
    }
}
