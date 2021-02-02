using Microsoft.EntityFrameworkCore;
using Verity.BankAPI.Entities.CurrentAccount;
using Verity.BankAPI.Repository.Generic;

namespace Verity.BankAPI.Repository.Context
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(DbContext context)
            : base(context)
        {
        }
    }
}
