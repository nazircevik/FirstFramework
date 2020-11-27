using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstFramework.Core;
using FirstFramework.Northwind.DataAcces.Concrete.EntityFramework;
using FirstFramework.Northwind.DataAcces.Concrete.NHibernate;
using FirstFramework.Northwind.DataAcces.Concrete.NHibernate.Helpers;

namespace FirstFramework.DataAcces.Tests
{
    /// <summary>
    /// Summary description for EntityFrameworkTest
    /// </summary>
    [TestClass]
    public class NHibernateTest
    {
       
        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.AreEqual(80, result.Count);
        }


        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p=>p.ProductName.Contains("ab"));
            Assert.AreEqual(4, result.Count);
        }

    }
}
