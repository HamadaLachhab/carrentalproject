using EXAM_PROJET.Data;
using EXAM_PROJET.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace EXAM_PROJET.Services
{
    public class OffreRepository : IOffreRepository
    {
        private readonly IVoitureRepository _voitureRepository;
        private readonly ApplicationDbContext _context;
        public OffreRepository(IVoitureRepository voitureRepository, ApplicationDbContext context)
        {
            _voitureRepository = voitureRepository;
            _context = context;
        }

        public  async Task<Offre> AddVoiture(int voitureId, double montant)
        {
            Offre of = new Offre() { voitureId = voitureId, montant = montant };
            _context.Add(of);
           await  _context.SaveChangesAsync();
            return  of;
            
        }

        public async  Task<bool> exist(int id)
        {
            var exist = await _context.Offres.Where(o => o.voitureId == id).FirstOrDefaultAsync();

            if (exist is null) return false;
            else return true;
               
        }

        public async Task<List<Voiture>> GetVoitures()
        {
            List<int> list =  await _context.Offres.Select(o => o.voitureId).ToListAsync();
            List<Voiture> listvoiture = new List<Voiture>();
            foreach ( var i in list)
            {
                listvoiture.Add(await _voitureRepository.GetVoitureById(i));
            }
            return listvoiture;
        }

        public async Task<bool> removeVoiture(int voitureId)
        {
            Offre v = await _context.Offres.Where(f => f.voitureId == voitureId).FirstOrDefaultAsync();
            if (v is null) return false;
            _context.Offres.Remove(v);
            await _context.SaveChangesAsync();
            return true;

        }

        public  async Task<Offre> updateOffre(int voitureId, double montant)
        {
            Offre v = await _context.Offres.Where(f => f.voitureId == voitureId).FirstOrDefaultAsync();
            v.montant = montant;
            await _context.SaveChangesAsync();
            return v;
        }
    }
}
