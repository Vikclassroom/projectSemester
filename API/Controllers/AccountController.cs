using API.Data;
using API.Dtos;
using API.Entities;
using API.Identity;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppAccount> _userManager;
        private readonly SignInManager<AppAccount> _signInManager;

        public AccountController(Context context, UserManager<AppAccount> userManager, SignInManager<AppAccount> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
                if (!EmailExists(account.Email)) { 
                    await _context.AddAsync(account);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return StatusCode(409, "Cet email est déjà utilisé");
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

                return Ok($"Le compte avec l'id {id} à bien été supprimé");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erreur à la suppression du compte");
            }
        }

        // User endpoint

        [HttpPost("login")]
        public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return StatusCode(404, "Le compte n'existe pas");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return StatusCode(401,"Le mot de passe ou le login son incorrect");

            return new AccountDto
            {
                Email = user.Email
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterDto registerDto)
        {
            var user = new AppAccount
            {
                Email = registerDto.Email
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest();

            return new AccountDto
            {
                Email = user.Email
            };
        }

        // Private Method bool

        //true or false
        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }

        private bool EmailExists(string email)
        {
            return _context.Accounts.Any(e => e.Email == email);
        }
    }
}

