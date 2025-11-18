using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication1.Interfaces;
using WebApplication1.DataAccess;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
   
            container.RegisterType<IUser, DAUser>();

            container.RegisterType<ITransaction, DATransaction>();

            container.RegisterType<ICategory, DACategory>();

            container.RegisterType<IFinancialGoal, DAFinancialGoal>();

            container.RegisterType<IWishList, DAWishList>();
      
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
