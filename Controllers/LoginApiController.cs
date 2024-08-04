using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Daper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginApiController : ControllerBase
    {
        private readonly SqliteConnection _connection = new SqliteConnection("Data Source:exampleData.db");
        
    }
}