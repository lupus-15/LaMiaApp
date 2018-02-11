using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaMiaApp.Models
{
    [Table("Appuntamenti")]
    public class Appuntamento
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        [Display(Name = "Titolo")]
        public string Titolo { get; set; }

        [Required]
        [Display(Name = "Data Inizio")]
        public DateTime DataInizio { get; set; }

        [Required]
        [Display(Name = "Data Fine")]
        public DateTime DataFine { get; set; }
        
        public ICollection<Trattamento> Trattamenti { get; set; }

        [Required]
        public Cliente Cliente { get; set; }


    }
}