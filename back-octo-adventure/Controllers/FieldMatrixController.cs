using back_octo_adventure.Models.FieldMatrix;
using back_octo_adventure.Models.ResponseWrapper;
using back_octo_adventure.Services.GenerateField;
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
        private IGenerateField _genF;
        public FieldMatrixController(IGenerateField genF) {
            _genF = genF;
        }

        [HttpGet("{rows}/{columns}")]
        public async Task<IActionResult> testCall(int rows, int columns) {

            ResponseWrapper<FieldGrid> Response = new ResponseWrapper<FieldGrid>();
            FieldGrid fGrid = _genF.GenerateFieldGrid(rows, columns);
            Response.body = fGrid;
            Response.message = "Holis :D";

            return Ok(Response);
        }

    }
}
