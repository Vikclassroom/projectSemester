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
    }
}
