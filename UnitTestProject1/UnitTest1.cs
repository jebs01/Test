using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using WebApplication1;
using System.Web.M





namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //}
    }

    [TestClass]
    public class TestLogonSimple
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //}

        [TestMethod]
        public  void TestLogon()
        {
            var controller = new HomeController();
            var result = HomeController.Logon() as ViewResult;
            Assert.AreEqual("Logon", result.ViewName);
            Assert.AreEqual(true, false);

        }
    }

  
   
}
