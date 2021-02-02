using Microsoft.EntityFrameworkCore;
using Verity.BankAPI.Entities.CurrentAccount;
using Verity.BankAPI.Repository.Generic;

namespace Verity.BankAPI.Repository.Context
{
    public class CurrentAccountRepository : Repository<CurrentAccount>, ICurrentAccountRepository
    {
        public CurrentAccountRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
