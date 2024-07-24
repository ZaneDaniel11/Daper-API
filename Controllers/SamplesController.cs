using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Daper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SamplesController : ControllerBase
    {
        // Get Data
    [HttpGet]
      public IActionResult Hello()
      {
            return Ok("Hello Nigga");
      }

        // Post DATA
    //    [HttpPost ("PostData")]

    //     public IActionResult PostData(string? Nname)
    //     {
    //         // if(string.IsNullOrEmpty(Nname))
    //         // {
    //         //     return BadRequest("Please enter a name");
    //         // }
    //         //   return Ok($"Hello {Nname}");
    //         if(Nname == null)
    //         {
    //             return BadRequest("Please enter your name");
    //         }
    //         else
    //         {
    //              return Ok($"Hello {Nname}");
    //         }
           
    //     }


        [HttpPost ("PostNum")]

        public IActionResult PostDataNum(int num1, int num2)
        {
              if(num1 == num2)
            {
                 return BadRequest("");
            }
            int max = Math.Max(num1, num2);
            return Ok($"{max}");

          
        }
    }

   
}