//<autogenerated/>
[assembly: WebActivator.PreApplicationStartMethod(typeof(FlightSim.Website.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(FlightSim.Website.App_Start.NinjectWebCommon), "Stop")]
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace FlightSim.Website.App_Start
{
    using System;
    using System.Web;
    using FlightSim.DataAccess;
    using FlightSim.DataAccess.Repositories;
    using FlightSim.Framework.Repositories;
    using FlightSim.Framework.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using NHibernate;
    using Ninject;
    using Ninject.Web.Common;

    /// <summary>
    /// Ninject class
    /// </summary>
    public static class NinjectWebCommon
    {
        /// <summary>
        /// Bootstrapper to use
        /// </summary>
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISession>().ToMethod(x => SQLSession.Instance.OpenSession()).InRequestScope();
            kernel.Bind<IExperimentRepository>().To<ExperimentRepository>();
            kernel.Bind<IConfigurationRepository>().To<ConfigurationRepository>();
            kernel.Bind<IExperimentService>().To<ExperimentService>();
            kernel.Bind<IConfigurationService>().To<ConfigurationService>();
        }        
    }
}
