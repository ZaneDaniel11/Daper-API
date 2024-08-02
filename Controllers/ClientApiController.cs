using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Dapper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientApiController : ControllerBase
    {
        private readonly SqliteConnection _connection = new SqliteConnection("Data Source=exampleData.db");

        [HttpGet("GetClients")]
        public async Task<IActionResult> GetClients()
        {
            const string query = "SELECT * FROM Client";
            var result = await _connection.QueryAsync<Client>(query);

            if (!result.Any())
                return BadRequest("Sample Error Message...");

            return Ok(result);
        }

        [HttpPost("SaveClient")]
        public async Task<IActionResult> SaveClientAsync(Client client)
        {
            const string query = "INSERT INTO Client (ClientName, Address) VALUES (@ClientName, @Address); SELECT * FROM Client ORDER BY Id DESC LIMIT 1";
            var result = await _connection.QueryAsync<Client>(query, client);

            return Ok(result);
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClientAsync(int Id, Client client)
        {
            const string query = "UPDATE Client SET ClientName = @theClientName, Address = @theAddress WHERE Id = @Id; SELECT * FROM Client WHERE Id = @Id LIMIT 1";
            var result = await _connection.QueryAsync<Client>(query, new
            {
                Id = Id,
                theClientName = client.ClientName,
                theAddress = client.Address
            });

            return Ok(result);
        }

        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int Id)
        {
            const string query = "DELETE FROM Client WHERE Id = @Id";
            await _connection.QueryAsync<Client>(query, new { Id = Id });

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            const string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            var user = await _connection.QuerySingleOrDefaultAsync<User>(query, new { login.Username, login.Password });

            if (user != null)
            {
                HttpContext.Session.SetString("username", user.Username);
                return Ok("Login successful");
            }

            return Unauthorized("Invalid username or password");
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return Ok("Logout successful");
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
       
    }
}
