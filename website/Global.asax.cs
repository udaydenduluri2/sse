﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ExternalServices;
using ExternalServices.Stubs;
using website.Controllers;

namespace website
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.MapMvcAttributeRoutes();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DependencyResolver.SetResolver(new BasicDependencyResolver());
        }

        public class BasicDependencyResolver : IDependencyResolver
        {
            public object GetService(Type serviceType)
            {
                IUtil util = new Util();
                return serviceType == typeof(TariffController) ?
                    new TariffController(new CustomerServiceStub(util), new AccountsServiceStub(), new PackageServiceStub(), new ExternalServices.Stubs.DiscountService(util), new TariffServiceStub()) :
                    null;
            }

            IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
            {
                return new object[0];
            }
        }
    }
}
