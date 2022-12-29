using EXAM_PROJET.Models;

namespace EXAM_PROJET.Services
{
    public interface IVoitureRepository
    {
        public Task<Voiture> GetVoitureById(int voitureId);
        public Task<bool> DeleteVoiture(int id);
        
    }
}
