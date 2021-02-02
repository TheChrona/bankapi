using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using Verity.BankAPI.Entities.CurrentAccount;
using Verity.BankAPI.Repository.Generic;

namespace Verity.BankAPI.Services.CurrentAccountService
{
    public class CurrentAccountService : ICurrentAccountService
    {

        protected ILog logger = LogManager.GetLogger(typeof(CurrentAccountService));

        public double Statement(CurrentAccount account)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new PlutoContext()))
                {
                    var balance = unitOfWork._currentAccount.Get(account.ClientId).Balance;

                    unitOfWork.Complete();

                    return balance;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Something went wrong while getting the statement " + ex.Message);
                throw new Exception("Something went wrong while getting the statement");
            }
        }

        public bool Transaction(Transaction transaction)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new PlutoContext()))
                {

                    var clientAccount = unitOfWork._currentAccount.Get(transaction.CurrentAccountId);

                    if (transaction.TransactionType == 1)
                    {
                        clientAccount.Balance = clientAccount.Balance + transaction.Value;
                    }
                    else if (transaction.TransactionType == 2)
                    {
                        clientAccount.Balance = clientAccount.Balance - transaction.Value;
                    } else
                    {
                        throw new Exception("Invalid transaction type");
                    }

                    unitOfWork._transaction.Add(transaction);

                    unitOfWork.Complete();

                    return true;

                }
            }
            catch (Exception ex)
            {
                logger.Error("Something went wrong while making the transaction " + ex.Message);
                throw new Exception("Something went wrong while making the transaction");
            }
        }
    }
}
