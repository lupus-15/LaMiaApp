using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaMiaApp.Models
{
    [Table("Trattamenti")]
    public class Trattamento
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Durata in minuti")]
        public short DurataInMinuti { get; set; }

        [Required]
        public string Prezzo { get; set; }

        public string Descrizione { get; set; }

        public virtual ICollection<Appuntamento> Appuntamenti { get; set; }

    }
}