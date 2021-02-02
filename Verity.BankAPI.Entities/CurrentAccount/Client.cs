using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Verity.BankAPI.Entities.CurrentAccount
{
    public class Client
    {

        [Key]
        [Column("ClientId", TypeName = "int")]
        [Display(Name = "Client ID")]
        public int ClientId { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
