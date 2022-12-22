using EXAM_PROJET.Data;
using EXAM_PROJET.Models;
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

        public Marque AddMarque(MarqueModel marqueModel)
        {
            var marque = new Marque() { NomMarque = marqueModel.NomMarque };
            _context.Marques.Add(marque);
            _context.SaveChanges();
            return marque;
        }

        public void DeleteMarque(int id)
        {
            var marque = _context.Marques.Where(e => e.MarqueId == id).FirstOrDefault();
            _context.Marques.Remove(marque);
            _context.SaveChanges();


        }

        public ICollection<Marque> GetAllMarque()
        {
            return _context.Marques.OrderBy(p => p.MarqueId).ToList();
        }

        public Marque GetMarque(int id)
        {
            return _context.Marques.Where(e => e.MarqueId == id).FirstOrDefault();
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
