//-----------------------------------------------------------------------
// <copyright file="SQLSession.cs" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FlightSim.DataAccess
{
    using System;
    using System.Reflection;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// SQLSession class
    /// </summary>
    public class SQLSession
    {
        /// <summary>
        /// Static instance of SQL Session class
        /// </summary>
        private static SQLSession instance = new SQLSession();

        /// <summary>
        /// Static volatile ISessionFactory field.
        /// </summary>
        private static volatile ISessionFactory sessionFactory;

        /// <summary>
        /// Object used to synchronize access to the session;
        /// </summary>
        private static object sessionSync = new object();

        /// <summary>
        /// Prevents a default instance of the <see cref="SQLSession" /> class from being created.
        /// </summary>
        private SQLSession()
        { 
        }

        /// <summary>
        /// Gets the ISessionFactory instance.
        /// </summary>
        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    lock (sessionSync)
                    {
                        if (sessionFactory == null)
                        {
                            sessionFactory = Configuration.BuildSessionFactory();
                        }
                    }
                }

                return sessionFactory;
            }
        }

        /// <summary>
        /// Gets the current <see cref="SQLSession" /> instance
        /// </summary>
        public static SQLSession Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the configuration for use
        /// </summary>
        private static NHibernate.Cfg.Configuration Configuration
        {
            get
            {
                var mapper = new ModelMapper();
                var configuration = new NHibernate.Cfg.Configuration();

                mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

                configuration.DataBaseIntegration(x =>
                {
                    x.Dialect<MsSql2012Dialect>();
                    x.ConnectionStringName = "db";
                });

                configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

                return configuration;
            }
        }

        /// <summary>
        /// Build the schema
        /// </summary>
        /// <param name="session">The session to use</param>
        public static void BuildSchema(ISession session)
        {
            new SchemaExport(Configuration).Execute(false, true, false, session.Connection, Console.Out);
        }

        /// <summary>
        /// Opens a stateless session.
        /// </summary>
        /// <returns>The open session.</returns>
        public static IStatelessSession OpenStatelessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }

        /// <summary>
        /// Opens the session.
        /// </summary>
        /// <returns>The open session.</returns>
        public ISession OpenSession()
        {
            ISession s = null;
            s = SessionFactory.OpenSession();
            s.FlushMode = FlushMode.Never;
            return s;
        }
    }
}
