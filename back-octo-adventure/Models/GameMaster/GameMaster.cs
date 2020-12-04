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

        /// <summary>
        /// Moves the position of the Character up north by one unit and returns true. If row position is
        /// equal or less than one, it means
        /// you are already at the upper top limit and returns false.
        /// </summary>
        /// <returns>false if couldn't move Or true if moved successfully</returns>
        public bool MoveCharacterNorth() {
            if (character.PositionRow <= 1)
                return false;
            character.PositionRow--;
            return true;
        }

        /// <summary>
        /// Moves the position of the character west by one unit and returns true. If column position
        /// is less or equal to one, it means you are already at the left border limit and return false.
        /// </summary>
        /// <returns>false if couldn't move Or true if moved successfully</returns>
        public bool MoveCharacterWest() {
            if (character.PositionColumn <= 1)
                return false;
            character.PositionColumn--;
            return true;
        }

        /// <summary>
        /// Moves the position of the character east by one unit and returns true. If column position
        /// is more or equal to the length of the inner array (the x axis), it means you
        /// are already at the rigth limit and returns false.
        /// </summary>
        /// <returns>false if couldn't move Or true if moved successfully</returns>
        public bool MoveCharacterEast() {
            if (character.PositionColumn >= playField.FieldGrid[0].Length - 1)
                return false;
            character.PositionColumn++;
            return true;
        }

        /// <summary>
        /// Moves the position of the character south by one unit and returns true. If column position
        /// is more or equal to the length of the outer array (the y axis), it means you are already at the
        /// bottom limit and returns false.
        /// </summary>
        /// <returns>false if couldn't move Or true if moved successfully</returns>
        public bool MoveCharacterSouth() {
            if (character.PositionRow >= playField.FieldGrid.Length - 1)
                return false;
            character.PositionRow++;
            return true;
        }
    }
}
