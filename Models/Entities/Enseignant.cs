using System.ComponentModel.DataAnnotations;

namespace GestionEDT_Core.Models.Entities
{
    public class Enseignant
    {
        [Key]
        public int IdEnseignant { get; set; }

        public string NomEnseignant { get; set; } = string.Empty;

        public string Adresse { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Specialite { get; set; } = string.Empty;

        public string Grade { get; set; } = string.Empty;
    }
}