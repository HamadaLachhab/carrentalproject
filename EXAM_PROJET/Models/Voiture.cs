using EXAM_PROJET.Models.User;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EXAM_PROJET.Models
{
    public class Voiture
    {
        [Key]
        public int VoitureId { get; set; }
        [Required(ErrorMessage = "Provide Price")]
        public string PrixParJour { get; set; }

        [Required(ErrorMessage = "Provide Year")]
        public string Annee { get; set; }

        [Required(ErrorMessage = "Provide Mileage")]
        [Range(1, int.MaxValue, ErrorMessage = "This Mileage is Invalid")]
        public string Kilometrage { get; set; }

        public Marque Marque { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Make")]
        public int MarqueId { get; set; }

        public Modele Modele { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a Model")]
        [DefaultValue("99")]
        Agence Agence { get; set; }
       
        public string Couleur { get; set; }

        public int Rating { get; set; }

        public string Immatriculation { get; set; }
        [DefaultValue("Description")]
        public string Description { get; set; }
        [DefaultValue("/path")]
        public string ImagePath { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public bool EstDisponible { get; set; }
        
        public virtual ICollection<Demande> Demandes { get; set; }
    }
}
