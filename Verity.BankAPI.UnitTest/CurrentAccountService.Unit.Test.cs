using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verity.BankAPI;
using Verity.BankAPI.Entities.CurrentAccount;
using Verity.BankAPI.Services.CurrentAccountService;

namespace Verity.BankAPI.UnitTest
{
    [TestClass]
    public class CurrentAccountServiceTest
    {
        [TestMethod]
        public void GettingNonNullStatementFromClientIdOne()
        {
            var currentAccountMock = new CurrentAccount()
            {
                ClientId = 1,
                CurrentAccountId = 1
            };

            var _currentAccountService = new CurrentAccountService();

            double result = _currentAccountService.Statement(currentAccountMock);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MakingADepositToCurrentAccountIdTwo()
        {
            var transactionMock = new Transaction()
            {
                ClientId = 2,
                CurrentAccountId = 2,
                TransactionType = 1
            };

            var _currentAccountService = new CurrentAccountService();

            var result = _currentAccountService.Transaction(transactionMock);

            Assert.IsTrue(result);
        }
    }
}
