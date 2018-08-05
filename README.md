# LMS
![Project requirement](https://github.com/helenmou/LMS/blob/master/LMS/images/project1.PNG)

Note:
```
In LMS/App-start/ Webapiconfig.cs

config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =Newtonsoft.Json.ReferenceLoopHandling.Ignore;
```
and also disable Lazy Loading

#### Autofac DI
 ====== 
NuGet install Autofac and Autofac.WebApi2
```
/BL/BusinessLogicCompositionRoot.cs
public class BusinessLogicCompositionRoot
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            //var currentAssembly = Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(currentAssembly)
            //    .Where(t => t.Name.EndsWith("Manager"))
            //    .AsImplementedInterfaces();
            builder.RegisterType<StudentManager>().As<IStudentManager>().InstancePerRequest();
            builder.RegisterType<UserManager>().As<IUserManager>().InstancePerRequest();
        }
    }
```
```
/Data/RepositoryCompositionRoot.cs
namespace Data
{
    public class RepositoryCompositionRoot
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            //var currentAssembly = Assembly.GetExecutingAssembly();

            //builder.RegisterAssemblyTypes(currentAssembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces();
            builder.RegisterType<LMSEntities>().AsSelf().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();

        }
    }
}
```
```
namespace LMS.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RepositoryCompositionRoot.RegisterTypes(builder);
            BusinessLogicCompositionRoot.RegisterTypes(builder);

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }
    }
}

namespace LMS.App_Start
{
    public class AutofacBootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}

```
```
LMS/Global
protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            AutomapperConfig.Initialize();
            AutofacBootstrapper.Run();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
```
