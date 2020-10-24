using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCORECRUD.Models
{
    public class TransactionModel
    {

        [Key]
        public int TransactionId { get; set; }

        [MaxLength(12)]
        [Required(ErrorMessage ="This Field is Mendatory")]
        [DisplayName("Account Number")]
        [Column(TypeName = "nvarchar(12)")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "This Field is Mendatory")]
        [DisplayName("Beneficiary Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string BeneficiaryName { get; set; }

        [Required(ErrorMessage = "This Field is Mendatory")]
        [DisplayName("Bank Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string BankName { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "This Field is Mendatory")]
        [DisplayName("SWIFT Code")]
        [Column(TypeName ="nvarchar(11)")]
        public string SWIFTCode { get; set; }

        [Required(ErrorMessage = "This Field is Mendatory")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString ="{0:MM/dd/yyy}")]
        public DateTime Date { get; set; }
    }
}
