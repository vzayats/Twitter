using TwitterApp.DAL.Repository.Interfaces;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TwitterApp.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TwitterApp.Web.App_Start.NinjectWebCommon), "Stop")]

namespace TwitterApp.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Mvc;
    using TwitterApp.Web.Infrastructure;
    using System.Web.Http;
    using TwitterApp.DAL.Repository;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                NinjectDependencyResolver ninjectResolver = new NinjectDependencyResolver(kernel);
                DependencyResolver.SetResolver(ninjectResolver); //MVC
                GlobalConfiguration.Configuration.DependencyResolver = ninjectResolver; //Web API

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IMessageRepository>().To<MessageRepository>();
            kernel.Bind<ISubscribeRepository>().To<SubscribeRepository>();
            kernel.Bind<ISubscriptionsRepository>().To<SubscriptionsRepository>();
        }        
    }
}