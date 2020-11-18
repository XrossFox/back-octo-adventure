using back_octo_adventure.Models.ResponseWrapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class FieldMatrixController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> testCall() {

            ResponseWrapper<int> Response = new ResponseWrapper<int>();
            Response.body = 69;
            Response.message = "Holis :D";

            return Ok(Response);
        }
    }
}
