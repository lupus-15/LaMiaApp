using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LaMiaApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Appuntamento> Appuntamenti { get; set; }
        public DbSet<Trattamento> Trattamenti { get; set; }
        public DbSet<Cliente> Clienti { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}