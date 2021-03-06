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
        [HttpGet("{idAccount}")]
        public async Task<ActionResult<IReadOnlyList<LinkDto>>> GetLinks(int idAccount)
        {

            var links = await _context.Links.Where(l => l.AccountId == idAccount).ToListAsync();

            return Ok(_mapper.Map<IReadOnlyList<LinkDto>>(links));
        }
    }
}
