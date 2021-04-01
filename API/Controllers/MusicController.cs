using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly Context _context;

        public MusicController(Context context)
        {
            _context = context;
        }

        //Get music/
        [HttpGet]
        public async Task<ActionResult<List<Music>>> GetMusics()
        {
            var accounts = await _context.Musics.ToListAsync();

            return Ok(accounts);
        }
        //Get music/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusic(int id)
        {
            return await _context.Musics.FindAsync(id);
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Music>> CreateMusic([Bind("MusicId,Title,Artist")] Music music)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(music);
                await _context.SaveChangesAsync();

                return Ok();
            }



            return StatusCode(500, "Une erreur est survenu lors de l'ajout du compte, une information est manquante");
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<Music>> DeleteMusic(int id)
        {
            try
            {
                var music = await _context.Musics.FindAsync(id);

                if (music == null)
                {
                    return NotFound($"La musique {id} est introuvable");
                }

                _context.Musics.Remove(music);
                await _context.SaveChangesAsync();

                return Ok($"La musique avec l'{id} à bien été supprimé");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erreur à la suppression de la musique");
            }
        }
    }
}
