using EXAM_PROJET.Data;
using EXAM_PROJET.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAM_PROJET.Services
{
    public class VoitureRepository : IVoitureRepository
    {
        private readonly ApplicationDbContext _context;
        public VoitureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteVoiture(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<Voiture> GetVoitureById(int voitureId)
        {
            return await _context.Voitures.FirstOrDefaultAsync(m => m.VoitureId == voitureId);
        }
    }
}
