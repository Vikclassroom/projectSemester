using API.Data;
using API.Dtos;
using API.Entities;
using AutoMapper;
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
    public class LinkController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public LinkController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get links/
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<LinkDto>>> GetLinks()
        {
            var links = await _context.Links.ToListAsync();

            return Ok(_mapper.Map<IReadOnlyList<LinkDto>>(links));
        }
        //Get link/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkDto>> GetLink(int id)
        {
            var link = await _context.Links.FindAsync(id);

            return _mapper.Map<Link, LinkDto>(link);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<LinkDto>> DeleteLink(int id)
        {
            try
            {
                var link = await _context.Links.FindAsync(id);

                if (link == null)
                {
                    return NotFound($"Le lien {id} est introuvable");
                }

                _context.Links.Remove(link);
                await _context.SaveChangesAsync();

                return Ok($"Le lien avec l'{id} à bien été supprimé");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erreur à la suppression du lien");
            }
        }
    }
}
