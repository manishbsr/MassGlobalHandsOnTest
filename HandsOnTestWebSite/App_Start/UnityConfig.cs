using System;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Unity.RegistrationByConvention;
using Unity.Interception.Utilities;
using Unity.Lifetime;
using Unity.Registration;
using HandsOnTest.DTOs.Constants;
using Unity.Injection;
namespace HandsOnTestWebSite
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<HandsOnTest.DataAccessLayer.Contracts.IEmployeeRepository, HandsOnTest.DataAccessLayer.EmployeeRepository>(new Unity.Lifetime.ContainerControlledLifetimeManager());
				//new Unity.Injection.InjectionConstructor(new object[] { "http://masglobaltestapi.azurewebsites.net" }));
			container.RegisterType<HandsOnTest.BusinessLayer.IEmployeeManagement, HandsOnTest.BusinessLayer.EmployeeManagement>(new Unity.Lifetime.ContainerControlledLifetimeManager());

			container.RegisterType<HandsOnTest.BusinessLayer.IEmployeeFactory, HandsOnTest.BusinessLayer.EmployeeFactory>(new Unity.Lifetime.ContainerControlledLifetimeManager());


			container.RegisterType<HandsOnTest.BusinessLayer.IEmployeeFactory, HandsOnTest.BusinessLayer.EmployeeFactory>(new Unity.Lifetime.ContainerControlledLifetimeManager());
			container.RegisterType<HandsOnTest.BusinessLayer.ISalaryCalculator, HandsOnTest.BusinessLayer.HourlySalaryCalculator>(EmployeeTypeContract.Hourly, new Unity.Lifetime.ContainerControlledLifetimeManager());
			container.RegisterType<HandsOnTest.BusinessLayer.ISalaryCalculator, HandsOnTest.BusinessLayer.MonthlySalaryCalculator>(EmployeeTypeContract.Monthy, new Unity.Lifetime.ContainerControlledLifetimeManager());

			container.RegisterType<Func<string, HandsOnTest.BusinessLayer.ISalaryCalculator>>
					(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new Func<string, HandsOnTest.BusinessLayer.ISalaryCalculator>
					((name) => c.Resolve<HandsOnTest.BusinessLayer.ISalaryCalculator>(name))));
			container.RegisterType<HandsOnTest.DataAccessLayer.ExternalSourceClient.IExternalSourceClientClient,
				HandsOnTest.DataAccessLayer.ExternalSourceClient.ExternalSourceClientClient>(new Unity.Lifetime.ContainerControlledLifetimeManager(), new Unity.Injection.InjectionConstructor(new object[] { new Uri("http://masglobaltestapi.azurewebsites.net") }));

			//var res= container.Resolve<>

			RegisterAutoMapperProfiles(container);
			

			

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
		private static void RegisterAutoMapperProfiles(IUnityContainer container)
		{

			var profiles = from t in typeof(HandsOnTest.ModelMapper.HourlyEmployeeProfile).Assembly.GetTypes()
						   where typeof(Profile).IsAssignableFrom(t)
						   select (Profile)Activator.CreateInstance(t);

			var config = new MapperConfiguration(cfg =>
			{
				foreach (var profile in profiles)
				{
					cfg.AddProfile(profile);
				}
			});

			container.RegisterInstance<IMapper>(config.CreateMapper(), new ContainerControlledLifetimeManager());
		}
	}
}