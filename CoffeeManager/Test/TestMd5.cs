using CoffeeManager.model;
using CoffeeManager.control;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System;

namespace Test
{
    [TestClass]
    public class TestMD5
    {
        [TestMethod]
        public void test()
        {
            string hashstring = hash.hashString("12345678");
            bool result = hash.verityPassword("12345678",hashstring);
        }

    }
}
