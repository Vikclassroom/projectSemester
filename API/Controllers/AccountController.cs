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

        [HttpPost("login")]
        public async Task<ActionResult<Account>> Login([Bind("Email,Password")] Account account)
        {
            var user = await _context.Accounts
                .Where(e => (e.Email == account.Email))
                .Where(p => (p.Password == account.Password))
                .FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }

            return BadRequest("Le mot de passe ou l\'email est incorrect ou inexistant");
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount([Bind("Email,Password")] Account account)
        {
            if (ModelState.IsValid)
            {
                account.UrlPicture = "placeholder.png";
                await _context.AddAsync(account);
                await _context.SaveChangesAsync();

                return new Account
                { 
                    AccountId = account.AccountId,
                    Email = account.Email,
                    Password = account.Password,
                    UrlPicture = account.UrlPicture
                };
            }

            return StatusCode(500, "Une erreur est survenu lors de l'ajout du compte, une information est manquante");
        }

        //Put
        [HttpPut("{id}")]
        public async Task<ActionResult<Account>> EditAccount(int id, [Bind("Email,Password")] Account account)
        {
            if (AccountExists(id) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(account);
                await _context.SaveChangesAsync();

                return new Account
                {
                    Email = account.Email,
                    Password = account.Password,
                    UrlPicture = account.UrlPicture
                };
            }
            return BadRequest();
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
        private bool AccountExists(int? id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }

        [HttpGet("emailExist")]
        public async Task<ActionResult<bool>> EmailExist(string email) 
        {
            var doesExist = await _context.Accounts.Where(e => e.Email == email).FirstOrDefaultAsync();
            if (doesExist == null)
            {
                return false;
            }

            return true;
        }
    }
}