using EXAM_PROJET.Models;

namespace EXAM_PROJET.Services
{
    public interface IDemandeRepository
    {
        public Task<ICollection<Demande>> getAll();
    }
}
