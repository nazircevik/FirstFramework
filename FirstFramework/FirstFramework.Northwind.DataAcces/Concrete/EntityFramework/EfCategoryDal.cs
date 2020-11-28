using FirstFramework.Core.DadaAcces.EntityFramework;
using FirstFramework.Northwind.DataAcces.Abstract;
using FirstFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FirstFramework.Northwind.DataAcces.Concrete.EntityFramework
{
    class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
