using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEDT_Core.Models.Entities
{
    public class Enseigner
    {
        [Key]
        public int Id { get; set; }

        public int IdProm { get; set; }

        [ForeignKey("IdProm")]
        public Promotion? Promotion { get; set; }

        public int IdEnseignant { get; set; }

        [ForeignKey("IdEnseignant")]
        public Enseignant? Enseignant { get; set; }
    }
}