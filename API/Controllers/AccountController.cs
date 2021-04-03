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
        private readonly SignInManager<AppAccount> _signInManager;
        private readonly UserManager<AppAccount> _userManager;

        public AccountController(Context context, SignInManager<AppAccount> signInManager, UserManager<AppAccount> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
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

        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> LoginAccount(LoginDto loginDto)
        {
            var account = await _userManager.FindByEmailAsync(loginDto.Email);
            if (account == null) return Unauthorized("Cette utilisateur n'existe pas");
            var result = await _signInManager.CheckPasswordSignInAsync(account, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized("Le mot de passe est faux");

            return new AccountDto
            {
                FirstName = account.UserName,
                Email = account.Email
            };

        }

        //Post
        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> RegisterAccount(RegisterDto registerDto)
        {
            var account = new AppAccount
            {
                UserName = registerDto.FirstName,
                Email = registerDto.Email
            };
            var result = await _userManager.CreateAsync(account, registerDto.Password);
            if (!result.Succeeded) return BadRequest();

            var accData = new Account
            {
                Email = account.Email,
                Password = account.PasswordHash,
                UrlPicture = "placeholder.png"
            };

            await _context.Accounts.AddAsync(accData);
            await _context.SaveChangesAsync();

            return new AccountDto
            {
                FirstName = account.UserName,
                Email = account.Email
            };
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

        //true or false
        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }

        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
    }
}

