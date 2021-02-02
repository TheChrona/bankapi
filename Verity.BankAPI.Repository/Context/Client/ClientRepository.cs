using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Verity.BankAPI.Entities.CurrentAccount;
using Verity.BankAPI.Repository.Generic;

namespace Verity.BankAPI.Repository.Context
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
