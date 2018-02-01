using Autofac;
using System.Web.Mvc;
using System.Reflection;
using Autofac.Integration.Mvc;

namespace Web
{
	public class InjectionConfig
	{
		public static void Init()
		{
			var builder = new ContainerBuilder();
			builder.RegisterControllers(Assembly.GetExecutingAssembly())
				   .PropertiesAutowired()
				   .InstancePerLifetimeScope();
			builder.RegisterAssemblyTypes(Assembly.Load("Business"));
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}