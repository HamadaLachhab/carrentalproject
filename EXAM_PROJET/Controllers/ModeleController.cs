using EXAM_PROJET.Data;
using EXAM_PROJET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAM_PROJET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeleController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ModeleController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modele = await _context.Modeles.ToListAsync();
            return Ok(modele);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ModeleModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Marques.FirstOrDefaultAsync(m => m.MarqueId == model.MarqueId);
            if (product == null)
                return BadRequest("id marque n'exist pas");
            Modele m = new Modele() { NomModel = model.NomModel,MarqueId =model.MarqueId };
            _context.Add(m);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
