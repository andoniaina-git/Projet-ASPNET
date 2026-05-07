using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEDT_Core.Models.Entities
{
    public class Matiere
    {
        [Key]
        public int IdMatiere { get; set; }

        public string NomMatiere { get; set; } = string.Empty;

        // Clé étrangère vers Enseignant
        public int IdEnseignant { get; set; }

        [ForeignKey("IdEnseignant")]
        public Enseignant? Enseignant { get; set; }
    }
}