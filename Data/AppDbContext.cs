using Microsoft.EntityFrameworkCore;
using GestionEDT_Core.Models.Entities;

namespace GestionEDT_Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<EDT> EDTs { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Enseigner> Enseigners { get; set; }
    }
}