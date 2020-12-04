using back_octo_adventure.Models.GameMaster;
using back_octo_adventure.Models.PlayerCharacter;
using back_octo_adventure.Models.ResponseWrapper;
using back_octo_adventure.Services.GenerateField;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _memoryCache;

        public GameMasterController(IGenerateField genField, IMemoryCache memoryCache) {
            _genField = genField;
            _memoryCache = memoryCache;
        }
        
        /// <summary>
        /// Creates a new game. Generates a new Field Matrix of the given size and creates a new Character instance. Saves
        /// the object into the memory cache, if the game already has been set, a new one is overwritten.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        [HttpGet("{rows}/{columns}")]
        public async Task<IActionResult> NewGame(int rows, int columns) {

            String currentSessionId = HttpContext.Session.Id;
            HttpContext.Session.SetString(currentSessionId, " Session has started");
            Console.WriteLine(">>>>> Current Session Id:"+currentSessionId);

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

            _memoryCache.Set<GameMaster>(currentSessionId, gameMaster);

            return Ok(response);
        }

        [HttpGet("CurrentGame")]
        public async Task<IActionResult> CurrentGame()
        {
            String currentSessionId = HttpContext.Session.Id;
            HttpContext.Session.SetString(currentSessionId, " Session has started");
            Console.WriteLine(">>>>> Current Session Id (Get Game):" + currentSessionId);

            ResponseWrapper<GameMaster> response = new ResponseWrapper<GameMaster>
            {
                message = "Current Game Recovered Succesfully",
                body = _memoryCache.Get<GameMaster>(currentSessionId)
            };
            return Ok(response);

        }
    }
}
