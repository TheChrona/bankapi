using System;
using System.Collections.Generic;
using System.Text;
using Verity.BankAPI.Entities.CurrentAccount;

namespace Verity.BankAPI.Services.CurrentAccountService
{
    public interface ICurrentAccountService
    {

        bool Transaction(Transaction transaction);

        double Statement(CurrentAccount account);

    }
}
