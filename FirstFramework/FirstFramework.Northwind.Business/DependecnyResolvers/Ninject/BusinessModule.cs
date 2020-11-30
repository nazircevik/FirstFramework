using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFramework.Core.DadaAcces;
using FirstFramework.Core.DadaAcces.EntityFramework;
using FirstFramework.Core.DataAcces.NHibernate;
using FirstFramework.Northwind.Business.Abstract;
using FirstFramework.Northwind.Business.Concrete.Managers;
using FirstFramework.Northwind.DataAcces.Abstract;
using FirstFramework.Northwind.DataAcces.Concrete.EntityFramework;
using FirstFramework.Northwind.DataAcces.Concrete.NHibernate.Helpers;
using Ninject.Modules;
namespace FirstFramework.Northwind.Business.DependecnyResolvers.Ninject
{
    class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQuerableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();

            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
