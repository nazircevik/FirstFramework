using FirstFramework.Northwind.Business.Abstract;
using FirstFramework.Northwind.DataAcces.Abstract;
using FirstFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFramework.Core;
using FirstFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FirstFramework.Northwind.Business.ValidationRules.FluentValidation;
using FirstFramework.Core.Aspects.Postsharp;
using System.Transactions;
using FirstFramework.Core.Aspects.Postsharp.TransacitionAspects;

namespace FirstFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
           // ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductID == id);
        }
        [TransactionScopeAspects]
        public void TransactionalOperation(Product product1, Product product2)
        {
               _productDal.Add(product1);
               _productDal.Update(product2);
             
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
           // ValidatorTool.FluentValidate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
    }
}
