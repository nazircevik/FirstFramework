using FirstFramework.Core.DataAcces.NHibernate;
using FirstFramework.Northwind.DataAcces.Abstract;
using FirstFramework.Northwind.Entities.ComplexTypes;
using FirstFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFramework.Northwind.DataAcces.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        NHibernateHelper _nHibernateHelper1;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper1 = nHibernateHelper;
        }

        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHibernateHelper1.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.CategoryID equals c.CategoryId
                             select new ProductDetail
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = p.ProductID,
                                 ProductName = p.ProductName

                             };
                            return result.ToList();
            }
        }
    }
}
