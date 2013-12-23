//-----------------------------------------------------------------------
// <copyright file="ConfigurationMap.cs" owner="Daniel Cooper">
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
    /// The database mapping for the configuration
    /// </summary>
    public class ConfigurationMap : ClassMapping<Configuration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationMap"/> class
        /// </summary>
        public ConfigurationMap()
        {
            this.Table("Configuration");

            this.Id(c => c.Id, m => { m.Generator(Generators.Identity); });

            this.Property(c => c.AtmosphericVisibility, m => { m.Type<Int32Type>(); });
            this.Property(c => c.InitialTargetSize, m => { m.Type<DoubleType>(); });
            this.Property(c => c.RealTargetSize, m => { m.Type<Int32Type>(); });
            this.Property(c => c.ClosingSpeed, m => { m.Type<Int32Type>(); });
            this.Property(c => c.UserDistance, m => { m.Type<Int32Type>(); });
            this.Property(c => c.MovingTargets, m => { m.Type<Int32Type>(); });
            this.Property(c => c.Active, m => { m.Type<BooleanType>(); });
            this.Property(c => c.Deleted, m => { m.Type<BooleanType>(); });
        }
    }
}
