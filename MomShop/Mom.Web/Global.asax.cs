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
            //ע��log4net
            log4net.Config.XmlConfigurator.Configure();


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //------ע��IOC
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();//�ѵ�ǰ�����е� Controller ��ע��
            //��Ҫ����.PropertiesAutowired()
            // ��ȡ����������ĳ���
            Assembly[] assemblies = new Assembly[] { Assembly.Load("Mom.Services") };
            builder.RegisterAssemblyTypes(assemblies)
            .Where(type => !type.IsAbstract&&typeof(IServices.IServicesBase).IsAssignableFrom(type))
            .AsImplementedInterfaces().PropertiesAutowired();
            var container = builder.Build();
            //ע��ϵͳ����� DependencyResolver�������� MVC ��ܴ��� Controller �ȶ����ʱ��
           // �ǹ� Autofac Ҫ����
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//!!!
            //-----------------------------------------------------------------------------------------------------

          
        }
    }
}
