using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mom.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册log4net
            log4net.Config.XmlConfigurator.Configure();


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //------注册IOC
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();//把当前程序集中的 Controller 都注册
            //不要忘了.PropertiesAutowired()
            // 获取所有相关类库的程序集
            Assembly[] assemblies = new Assembly[] { Assembly.Load("Mom.Services") };
            builder.RegisterAssemblyTypes(assemblies)
            .Where(type => !type.IsAbstract&&typeof(IServices.IServicesBase).IsAssignableFrom(type))
            .AsImplementedInterfaces().PropertiesAutowired();
            var container = builder.Build();
            //注册系统级别的 DependencyResolver，这样当 MVC 框架创建 Controller 等对象的时候都
           // 是管 Autofac 要对象。
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//!!!
            //-----------------------------------------------------------------------------------------------------

          
        }
    }
}
