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
        [HttpGet("idAccount")]
        public async Task<ActionResult<List<Music>>> GetMusics(int idAccount)
        {
            var musics = await _context.Links.Where(l => l.AccountId == idAccount).Select(l => l.Music).ToListAsync();
            return musics;
        }

        //Post
        [HttpPost("{accountId}")]
        public async Task<ActionResult<Music>> CreateMusic([Bind("Title,Artist")] Music music, int accountId)
        {
            if (ModelState.IsValid)
            {
                var musicRow = await _context.Musics.Where(e => e.Title == music.Title).FirstOrDefaultAsync();

                if (musicRow == null)
                {
                    var musics = new Music
                    {
                        Artist = music.Artist,
                        Title = music.Title
                    };

                    await _context.AddAsync(musics);
                    await _context.SaveChangesAsync();
                    musicRow = await _context.Musics.FindAsync(musics.MusicId);
                }

                var link = new Link
                {
                    AccountId = accountId,
                    MusicId = musicRow.MusicId
                };

                await _context.Links.AddAsync(link);
                await _context.SaveChangesAsync();

                return new Music 
                { 
                    Artist = music.Artist,
                    Title = music.Title
                };
            }

            return StatusCode(500, "Une erreur est survenu lors de l'ajout de la musique, une information est manquante");
        }

        //Delete
        [HttpDelete("{id}/{idAccount}")]
        public async Task<ActionResult<Music>> DeleteMusic(int id, int idAccount)
        {
            try
            {
                var music = await _context.Musics.FindAsync(id);

                if (music == null)
                {
                    return NotFound($"La musique {id} est introuvable");
                }

                var linkToDelete = await _context.Links.Where(m => m.MusicId == music.MusicId).Where(u => u.AccountId == idAccount).FirstOrDefaultAsync();
                _context.Links.Remove(linkToDelete);
                await _context.SaveChangesAsync();

                var AnyOtherRelated = await _context.Links.Where(m => m.MusicId == music.MusicId).FirstOrDefaultAsync();
                if (AnyOtherRelated == null) 
                {
                    _context.Musics.Remove(music);
                    await _context.SaveChangesAsync();
                }

                return Ok($"La musique avec l'id {id} à bien été supprimé de la liste");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erreur à la suppression de la musique");
            }
        }
    }
}
