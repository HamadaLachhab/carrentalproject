using EXAM_PROJET.Data;
using EXAM_PROJET.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace EXAM_PROJET.Services
{
    public class MarqueRepository : IMarqueRepository
    {
        private readonly  ApplicationDbContext _context;

        public MarqueRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Marque> AddMarque(MarqueModel marqueModel)
        {
            var marque = new Marque() { NomMarque = marqueModel.NomMarque };
           await  _context.Marques.AddAsync(marque);
            await _context.SaveChangesAsync();
            return marque;
        }

        public async Task<bool> DeleteMarque(int id)
        {
            var marque =  await _context.Marques.FindAsync(id);
            if (marque is null) return false;
             await _context.SaveChangesAsync();
            return true;


        }

        public async Task<ICollection<Marque>> GetAllMarque()
        {
            return  await _context.Marques.ToListAsync();
        }

        public async Task<Marque> GetMarque(int id)
        {
            return await _context.Marques.FirstOrDefaultAsync(m => m.MarqueId == id);
        }

        public bool UpdateMarque(MarqueModel marque,int id)
        {
            var m  = _context.Marques.Where(e => e.MarqueId == id).FirstOrDefault();
            m.NomMarque = marque.NomMarque;
            _context.SaveChanges();
            return true;

        }
    }
}
