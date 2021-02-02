using System;
using System.Collections.Generic;
using System.Text;
using Verity.BankAPI.Entities.CurrentAccount;
using Verity.BankAPI.Repository.Generic;

namespace Verity.BankAPI.Repository.Context
{
    public interface ITransactionRepository : IRepository<Transaction> 
    {
    }
}
