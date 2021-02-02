using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Verity.BankAPI.Entities.CurrentAccount
{
    public class CurrentAccount
    {
        [Key]
        [Column("CurrentAccountId", TypeName = "int")]
        [Display(Name = "CurrentAccount ID")]
        [Required]
        public int CurrentAccountId { get; set; }

        [Column("Balance", TypeName = "float")]
        [Display(Name = "Balance")]
        public double Balance { get; set; }

        [ForeignKey("ClientId")]
        [Column("ClientId", TypeName = "int")]
        [Display(Name = "Client ID")]
        [Required]
        public int ClientId { get; set; }

        [Column("AccountNumber")]
        [Display(Name = "Account Number")]
        [Required]
        public string AccountNumber { get; set; }

        [Column("Password")]
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
    }
}
