using FirstFramework.Core.DadaAcces;
using FirstFramework.Northwind.Entities.Concrete;
using FirstFramework.Northwind.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFramework.Northwind.DataAcces.Abstract
{
   public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
