using EXAM_PROJET.Models;

namespace EXAM_PROJET.Services
{
    public interface IMarqueRepository
    {
        public ICollection<Marque> GetAllMarque();
        public Marque GetMarque(int id);
        public Marque AddMarque(MarqueModel marqueModel);
        public void DeleteMarque(int id);   
        public bool UpdateMarque(MarqueModel marque,int id);
    }
}
