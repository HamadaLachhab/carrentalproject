using System.ComponentModel.DataAnnotations;

namespace EXAM_PROJET.Models
{
    public class Agence
    {
        [Key]
        public int AgenceId { get; set; }

        public string Name { get; set; }
        public virtual ICollection<Voiture> Voitures { get; set; }  
    }
}
