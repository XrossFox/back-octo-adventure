using back_octo_adventure.Models.GameMaster;
using back_octo_adventure.Models.PlayerCharacter;
using back_octo_adventure.Models.ResponseWrapper;
using back_octo_adventure.Services.GenerateField;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class GameMasterController: ControllerBase
    {

        private GameMaster gameMaster;
        private IGenerateField _genField;

        public GameMasterController(IGenerateField genField) {
            _genField = genField;
        }
        
        /// <summary>
        /// Creates a new game. Generates a new Field Matrix of the given size and creates a new Character instance.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        [HttpGet("{rows}/{columns}")]
        public async Task<IActionResult> NewGame(int rows, int columns) {

            gameMaster = new GameMaster {
                playField = _genField.GenerateFieldGrid(rows, columns),
                character = new Character {
                    PositionRow = 1,
                    PositionColumn = 1
                }
            };

            ResponseWrapper<GameMaster> response = new ResponseWrapper<GameMaster>
            {
                message = "New Game Created!",
                body = gameMaster
            };

            return Ok(response);
        }
    }
}
