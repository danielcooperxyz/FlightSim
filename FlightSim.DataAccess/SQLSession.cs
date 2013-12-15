using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightSim.DataAccess
{
    public class SQLSession
    {
        public static ISessionFactory sessionFactory = CreateSessionFactory();

        public void Dispose()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Dispose();
            }
        }

        /// <summary>
        /// Creates a session factory
        /// </summary>
        /// <returns></returns>
        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = new Configuration();
            configuration.Configure();
            var sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory;
        }

        public static ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
