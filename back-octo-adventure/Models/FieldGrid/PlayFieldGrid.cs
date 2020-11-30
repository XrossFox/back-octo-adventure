using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Models.FieldMatrix
{

    /// <summary>
    /// Model that represents the field grid for the gameplay. Displayed by the front end.
    /// </summary>
    public class PlayFieldGrid
    {
        public String[][] FieldGrid { get; set; }

    }
}
