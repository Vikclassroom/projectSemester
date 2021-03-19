using API.Data;
using API.Dtos;
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
    public class LinkController : ControllerBase
    {
        private readonly Context _context;

        public LinkController(Context context)
        {
            _context = context;
        }
        
        //Get link/
        [HttpGet]
        public async Task<ActionResult<List<LinkDto>>> GetLinks()
        {
            var links = await _context.Links.ToListAsync();

            return links.Select(links => new LinkDto
            {
                LinkId = links.LinkId,
                AccountId = links.AccountId,
                MusicId = links.MusicId
            }).ToList();
        }
    }
}
