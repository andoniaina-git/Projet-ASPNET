using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEDT_Core.Models.Entities
{
    public class Promotion
    {
        [Key]
        public int IdProm { get; set; }

        public string NomProm { get; set; } = string.Empty;

        public string Mention { get; set; } = string.Empty;

        public string Niveau { get; set; } = string.Empty;

        // Salle principale (optionnel selon ton besoin)
        public string CodeSalle { get; set; } = string.Empty;

        [ForeignKey("CodeSalle")]
        public Salle? Salle { get; set; }
    }
}