using EXAM_PROJET.Models.User;

namespace EXAM_PROJET.Models
{
    public class Demande
    {
        public string Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int VoitureId { get; set; }
        public Voiture Voiture { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public Double PrixTotal { get; set;}
        public string statut { get; set; }

    }
}
