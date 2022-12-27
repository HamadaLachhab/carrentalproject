using EXAM_PROJET.Data;
using EXAM_PROJET.Models;
using EXAM_PROJET.Models.User;
using EXAM_PROJET.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAM_PROJET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoitureController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
   
        private readonly UserManager<ApplicationUser> _userManager;
        public VoitureController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
                 
                    _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var marque = await _context.Voitures.ToListAsync();
            return Ok(marque);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VoitureModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var product = await _context.Marques.FirstOrDefaultAsync(m => m.MarqueId == model.MarqueId);
            if (product == null)
                return BadRequest("id marque n'exist pas");

            var Modele = await _context.Modeles.FirstOrDefaultAsync(m => m.ModeleId == model.ModeleId);
            if (product == null)
                return BadRequest("id modele n'exist pas");

            var  mymodele = await _context.Modeles.FirstOrDefaultAsync(m => m.ModeleId == model.ModeleId);

            if (await _userManager.FindByIdAsync(model.ProprietaireId) is  null)
                return BadRequest("id user n'exist pas ");
            ApplicationUser myprop = await _userManager.FindByIdAsync(model.ProprietaireId);

            Voiture m = new Voiture() {
                Annee=model.Annee,
                PrixParJour=model.PrixParJour,
                Kilometrage=model.Kilometrage,
                MarqueId=model.MarqueId,
                Modele=mymodele,
                Couleur=model.Couleur,
                Rating=model.Rating,
                ImagePath=model.ImagePath,
                ApplicationUser=myprop,
                EstDisponible = model.EstDisponible,
                Immatriculation=model.Immatriculation,
                Description=model.Description

            };
             _context.Add(m);
            await _context.SaveChangesAsync();
            return Ok( m);
        }
    }
}
