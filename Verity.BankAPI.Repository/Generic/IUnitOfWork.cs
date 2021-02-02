using System;
using Verity.BankAPI.Repository.Context;

namespace Verity.BankAPI.Repository.Generic
{
    interface IUnitOfWork : IDisposable
    {
        ICurrentAccountRepository _currentAccount { get; }
        ITransactionRepository _transaction { get; }
        IClientRepository _client { get; }
        int Complete();
    }
}
