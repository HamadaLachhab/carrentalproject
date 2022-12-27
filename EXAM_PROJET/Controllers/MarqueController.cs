﻿using EXAM_PROJET.Data;
using EXAM_PROJET.Models;
using EXAM_PROJET.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EXAM_PROJET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarqueController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MarqueController(ApplicationDbContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var marque =  await _context.Marques.ToListAsync();
            return Ok(marque);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarqueModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Marque m = new Marque() { NomMarque = "ahamda" };
            Console.WriteLine(m.NomMarque is null ? "============\n\n\n\n\n\n\n=========":"good");
            _context.Add(m);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
