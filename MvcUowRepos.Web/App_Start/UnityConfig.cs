using Microsoft.Practices.Unity;
using MvcUowRepos.Repository;
using MvcUowRepos.Services.IMvcUowReposServices;
using MvcUowRepos.Services.MvcUowReposServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc4;

namespace MvcUowRepos.Web.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IMvcUow, MvcUow>();
            //container.RegisterType<IMvcRepository<T>, MvcRepository<T>>();
            container.RegisterType<IUserService, UserService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}