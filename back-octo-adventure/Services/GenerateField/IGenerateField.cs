using back_octo_adventure.Models.FieldMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Services.GenerateField
{
    public interface IGenerateField 
    {
        public FieldGrid GenerateFieldGrid(int rows, int columns);
    }
}
