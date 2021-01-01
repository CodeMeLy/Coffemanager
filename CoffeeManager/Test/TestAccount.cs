using CoffeeManager.model;
using CoffeeManager.control;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System;

namespace Test
{
    [TestClass]
    public class TestAccount
    {
        [TestMethod]
        public void CreateAdminAcount()
        {
            Account account = new Account("admin1", "12345678", Role.ADMIN);
            AccountManager manager = new AccountManager();
            manager.createAccount(account);

        }
        [TestMethod]
        public void CreateEmployeeAcount()
        {
            Account account = new Account("user1", "12345678", Role.EMPLOYEE);
            AccountManager manager = new AccountManager();
            manager.createAccount(account);

        }
        [TestMethod]
        public void getEmployeeAcount()
        {
            AccountManager manager = new AccountManager();
            System.Collections.Generic.List<Account> account = manager.getAccountFromDb();
        }
    }
}
