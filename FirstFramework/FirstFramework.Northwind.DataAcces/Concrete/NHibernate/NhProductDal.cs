using FirstFramework.Core.DataAcces.NHibernate;
using FirstFramework.Northwind.DataAcces.Abstract;
using FirstFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFramework.Northwind.DataAcces.Concrete.NHibernate
{
   public class NhProductDal:NhEntityRepositoryBase<Product>,IProductDal
    {
        public NhProductDal(NHibernateHelper nHibernateHelper):base(nHibernateHelper)
        {

        }
    }
}
