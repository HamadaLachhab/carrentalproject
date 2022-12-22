using EXAM_PROJET.Models;
using EXAM_PROJET.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EXAM_PROJET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarqueController : ControllerBase
    {
        public MarqueController(IMarqueRepository marqueRepository)
        {
            _marqueRepository = marqueRepository;
        }

        public IMarqueRepository _marqueRepository { get; }

        [HttpGet]
        public IActionResult GetAllmarque()
        {
            var marque = _marqueRepository.GetAllMarque();
            return Ok(marque);
        }
        [HttpGet("{id}")]
        public IActionResult Getmarque(int id )
        {
            var marque = _marqueRepository.GetMarque(id);
            return Ok(marque);
        }
        [HttpPost]
        public IActionResult CreateMarque([FromBody] MarqueModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var marque = _marqueRepository.AddMarque(model);
            return Ok(marque);
        }
        [HttpPut("{id}")]
        public IActionResult updatemarque([FromQuery]int  id , [FromBody] MarqueModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var t = _marqueRepository.UpdateMarque(model, id);
            return Ok("updated succesfully");
        }

    }
}
