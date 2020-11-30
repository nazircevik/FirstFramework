using System;
using FirstFramework.Northwind.Business.Concrete.Managers;
using FirstFramework.Northwind.DataAcces.Abstract;
using FirstFramework.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentValidation;
namespace FirstFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_Valudaiton_Check()
        {
            Mock<IProductDal> moc = new Mock<IProductDal>();
            ProductManager productmanager= new ProductManager(moc.Object);
            productmanager.Add(new Product());
        }
    }
}
