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
    public class AccountController : ControllerBase
    {
        private readonly Context _context;

        public AccountController(Context context)
        {
            _context = context;
        }

        //Get account/
        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAccounts()
        {
            var accounts = await _context.Accounts.ToListAsync();

            return Ok(accounts);
        }
        //Get account/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount([Bind("AccountId,Email,Password,UrlPicture")] Account account)
        {
            if (ModelState.IsValid) {
                _context.AddAsync(account);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return StatusCode(500, "Une erreur est survenu lors de l'ajout du compte, une information est manquante");
        }

        //Put
        [HttpPut("{id}")]
        public async Task<ActionResult<Account>> EditAccount(int id, [Bind("AccountId,Email,Password,UrlPicture")] Account account)
        {
            if (id != account.AccountId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound($"Le compte {id} n'a pas été trouvé");
                    }
                }
            }
            return NoContent();
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(id);

                if (account == null)
                {
                    return NotFound($"Le compte {id} est introuvable");
                }

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();

                return Ok($"Le compte avec l'{id} à bien été supprimé");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erreur à la suppression du compte");
            }

        }

        //true or false
        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}

