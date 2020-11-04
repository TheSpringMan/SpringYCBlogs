using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SpringYCBlogs.Infrastructure;
using SpringYCBlogs.Infrastructure.Concrete;
using SpringYCBlogs.Infrastructure.Repository;
using SpringYCBlogs.Service;
using System.Data.Entity;

namespace SpringYCBlogs.UI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private readonly IKernel kernel;

        public static NinjectDependencyResolver Instance
        {
            get { return new NinjectDependencyResolver(); }
        }
        public NinjectDependencyResolver()
        {
            this.kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return this.kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<DbContext>().To<EFDbContext>().InSingletonScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();

            #region Service库
            kernel.Bind<IAccountService>().To<AccountService>();
            #endregion

            #region UI库中的绑定
            
            #endregion
        }
    }
}