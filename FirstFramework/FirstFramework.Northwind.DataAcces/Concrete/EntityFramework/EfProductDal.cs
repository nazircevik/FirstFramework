using FirstFramework.Core.DadaAcces.EntityFramework;
using FirstFramework.Northwind.DataAcces.Abstract;
using FirstFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstFramework.Northwind.DataAcces.Concrete.EntityFramework
{
   public class EfProductDal :EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
       
    }
}
