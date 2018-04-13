using Evolent.Services.Interfaces;
using Evolent.Services.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Evolent.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
              container.RegisterType<IContactServices, ContactServices>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}