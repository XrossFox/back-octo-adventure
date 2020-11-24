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

        /// <summary>
        /// Constructor is injected with an instance of IGenerateFieldService. This service create the field grids at will.
        /// </summary>
        /// <param name="genF"></param>
        public FieldMatrixController(IGenerateField genF) {
            _genF = genF;
        }
        /// <summary>
        /// Api endpoint: fieldmatrix/{rows}/{columns}. Returns a generated field grid model.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
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
