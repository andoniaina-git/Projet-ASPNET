using System.ComponentModel.DataAnnotations;

namespace GestionEDT_Core.Models.Entities
{
    public class Salle
    {
        [Key]
        public string CodeSalle { get; set; } = string.Empty;

        public int Capacite { get; set; }

        public string NomBatiment { get; set; } = string.Empty;
    }
}