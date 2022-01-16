using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentsScheduler.Model;
using Microsoft.AspNetCore.Cors;

namespace AppointmentsScheduler
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BLL.BLLUser _bllUser;

        public UsersController(BLL.BLLUser context)
        {
            _bllUser = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _bllUser.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _bllUser.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                 _bllUser.UpdateUser(user);
            }
            catch (Exception ex)
            {
                if (!_bllUser.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    //Log
                    return BadRequest();
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user, string password)
        {
            try
            {
                await _bllUser.InsertUser(user, password);

                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _bllUser.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            await _bllUser.DeleteUser(user);

            return NoContent();
        }

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("Authenticate")]
        public ActionResult Authenticate(string email, string password)
        {
            try
            {
                var validUser = _bllUser.Authenticate(email, password);

                if (!validUser)
                {
                    return Unauthorized();
                }

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}
