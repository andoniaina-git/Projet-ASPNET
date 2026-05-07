using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEDT_Core.Models.Entities
{
    public class EDT
    {
        [Key]
        public int IdEDT { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan HeureDebut { get; set; }

        public TimeSpan HeureFin { get; set; }

        // Clé étrangère Salle (CodeSalle est PK dans Salle)
        public string CodeSalle { get; set; } = string.Empty;

        [ForeignKey("CodeSalle")]
        public Salle? Salle { get; set; }

        // Matière
        public int IdMatiere { get; set; }

        [ForeignKey("IdMatiere")]
        public Matiere? Matiere { get; set; }

        // Enseignant
        public int IdEnseignant { get; set; }

        [ForeignKey("IdEnseignant")]
        public Enseignant? Enseignant { get; set; }
    }
}