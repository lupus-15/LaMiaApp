using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LaMiaApp.Models
{
    [Table("Clienti")]
    public class Cliente
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public String Nome { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public String Cognome { get; set; }
        
        [Required]
        [StringLength(maximumLength: 30)]
        [Display(Name = "Numero di Telefono")]
        public String NumeroTelefono { get; set; }

        public String Email { get; set; }
        
    }
}