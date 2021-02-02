using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Verity.BankAPI.Entities.CurrentAccount;
using Verity.BankAPI.Repository.Context;

namespace Verity.BankAPI.Repository.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _currentAccount = new CurrentAccountRepository(_context);
            _transaction = new TransactionRepository(_context);
            _client = new ClientRepository(_context);
        }

        public ICurrentAccountRepository _currentAccount { get; private set; }
        public ITransactionRepository _transaction { get; private set; }
        public IClientRepository _client { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
