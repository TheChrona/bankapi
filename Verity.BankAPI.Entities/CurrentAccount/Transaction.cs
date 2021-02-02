using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Verity.BankAPI.Entities.CurrentAccount
{
    public class Transaction
    {
        
        [Key]
        [Column("TransactionId", TypeName = "int")]
        [Display(Name = "Transaction ID")]        
        public int TransactionId { get; set; }

        [ForeignKey("ClientId")]
        [Column("ClientId", TypeName = "int")]
        [Display(Name = "Client ID")]
        [Required]
        public int ClientId { get; set; }

        [ForeignKey("CurrentAccountId")]
        [Column("CurrentAccountId", TypeName = "int")]
        [Display(Name = "Current Account ID")]
        [Required]
        public int CurrentAccountId { get; set; }

        [Column("TransactionDate", TypeName = "datetime")]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; }

        [Column("Value", TypeName = "double")]
        [Display(Name = "Transaction Value")]
        [Required]
        public double Value { get; set; }

        [Column("TransactionType", TypeName = "int")]
        [Display(Name = "Transaction Type")]
        [Required]
        public int TransactionType { get; set; }

    }
}
