using Amazon.DynamoDBv2.DataModel;
using DynamoDB_With_Crud.Models;
using DynamoDB_With_Crud.Models.DynamoStudentManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DynamoDB_With_Crud.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDynamoDBContext _context;
        public UsersController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _context.ScanAsync<Users>(default).GetRemainingAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }

        }

        [HttpGet("{email},{city}")]
        public async Task<IActionResult> GetByEmail(string email,string city)
        {
            var student = await _context.LoadAsync<Users>(email,city);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(Users user)
        {
            try
            {
                var userRequest = await _context.LoadAsync<Users>(user.Email,user.City);
                if (userRequest != null) return BadRequest($"User with Email {user.Email} Already Exists");
                await _context.SaveAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
          
        }
        [HttpDelete("{email},{city}")]
        public async Task<IActionResult> DeleteUser(string email,string city)
        {
            var user = await _context.LoadAsync<Users>(email,city);
            if (user == null) return NotFound();
            await _context.DeleteAsync(user);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(Users usrrequest)
        {
            var user = await _context.LoadAsync<Users>(usrrequest.Email, usrrequest.City);
            if (user == null) return NotFound();
            await _context.SaveAsync(usrrequest);
            return Ok(usrrequest);
        }

    }
}
