using Microsoft.EntityFrameworkCore;
using Verity.BankAPI.Entities.CurrentAccount;

namespace Verity.BankAPI.Repository.Generic
{
    public class PlutoContext : DbContext
    {

        public PlutoContext()
            : base()
        {
        }

        public virtual DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Diogo\Desktop\Projetos\Verity.BankAPI\Verity.BankAPI.Repository\Bank.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .ToTable("Client")
                .HasKey("ClientId");

            modelBuilder.Entity<Transaction>()
                .ToTable("Transaction")
                .HasKey("TransactionId");

            modelBuilder.Entity<Transaction>()
                .Property("TransactionDate")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CurrentAccount>()
                .ToTable("CurrentAccount")
                .HasKey("CurrentAccountId");
        }

    }
}
