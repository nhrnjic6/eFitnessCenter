using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS2_Seminarski.Database;

namespace RS2_Seminarski.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly FitnessCenterDbContext _context;

        public TokenController(FitnessCenterDbContext context)
        {
            _context = context;
        }

        // GET: api/Token
        [HttpGet]
        public IEnumerable<AppUser> GetAppUsers()
        {
            return _context.AppUsers
                .Include(user => user.Employee)
                .Include(user => user.Client)
                .ToList();
        }

        // GET: api/Token/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await _context.AppUsers.FindAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            return Ok(appUser);
        }

        // PUT: api/Token/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser([FromRoute] int id, [FromBody] AppUser appUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Token
        [HttpPost]
        public async Task<IActionResult> PostAppUser()
        {
            AppUser client = new AppUser
            {
                FirstName = "Nihad",
                LastName = "Hrnjic",
                Email = "nhiap6@gmail.com",
                PhoneNumber = "0603566401",
                Status = UserStatus.ACTIVE,
                CreatedAt = DateTime.Now,
                HashedPassword = "password",
                Address = "Hadzeli.42",
                Client = new Client()
            };

            AppUser employee = new AppUser
            {
                FirstName = "Mujo",
                LastName = "Mujic",
                Email = "mujo@gmail.com",
                PhoneNumber = "0603566401",
                Status = UserStatus.ACTIVE,
                CreatedAt = DateTime.Now,
                HashedPassword = "password",
                Address = "Hadzeli.42",
                Employee = new Employee()
            };

            _context.AppUsers.Add(client);
            _context.AppUsers.Add(employee);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Token/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return Ok(appUser);
        }

        private bool AppUserExists(int id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}