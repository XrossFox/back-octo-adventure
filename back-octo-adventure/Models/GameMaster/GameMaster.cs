using back_octo_adventure.Models.FieldMatrix;
using back_octo_adventure.Models.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Models.GameMaster
{
    public class GameMaster
    {
        public PlayFieldGrid playField { get; set; }
        public Character character { get; set; }
    }
}
