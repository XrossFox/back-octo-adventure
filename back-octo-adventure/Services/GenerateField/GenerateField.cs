using back_octo_adventure.Models.FieldMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Services.GenerateField
{
    public class GenerateField : IGenerateField
    {
        public FieldGrid GenerateFieldGrid(int rows, int columns)
        {
            FieldGrid fGrid = new FieldGrid();

            fGrid.FieldGridArray = new string[rows, columns];

            // if bool is false, then terrain will be stone, else will be dirt.
            Random random = new Random();
            bool dirtOrStone = random.Next(0, 10) > 5 ? true: false;

            for (int row = 0; row < fGrid.FieldGridArray.GetLength(0); row++) {

                for (int col = 0; col < fGrid.FieldGridArray.GetLength(1); col++) {

                    // if it's a upper corner tile, either left or right
                    if ((row == 0 && col == 0) || (row == 0 && col == columns - 1))
                    {
                        // its the left one
                        if (col == 0)
                            fGrid.FieldGridArray[row, col] = "CUL";
                        // its the right one
                        else
                            fGrid.FieldGridArray[row, col] = "CUR";
                        continue; // go-to next cycle jail, or add a tile where it shouldn't be 
                    }

                    // if it's a lower corner tile, either left or right
                    if ((row == rows - 1 && col == 0) || (row == rows - 1 && col == columns - 1))
                    {   
                        // left
                        if (col == 0)
                            fGrid.FieldGridArray[row, col] = "CDL";
                        else
                            fGrid.FieldGridArray[row, col] = "CDR";
                        continue; 
                    }

                    // if it's the upper row, but not the corners
                    if ((row == 0) && (col > 0 && col < columns - 1))
                    {
                        fGrid.FieldGridArray[row, col] = "UpB";
                        continue; // go-to next cycle jail, or add a tile where it shouldn't be 
                    }

                    // if it's the lower row, but not the corners
                    if ((row == rows - 1) && (col > 0 && col < columns - 1))
                    {
                        fGrid.FieldGridArray[row, col] = "LwB";
                        continue; // go-to next cycle jail, or add a tile where it shouldn't be 
                    }

                    // if it's the left/right border but not of the first/last row. weirdest-ass if ever. might as well do ML with this shit
                    if (
                      (col == 0 && (row > 0 && row < rows - 1)) // col is 0, so its left border, but row is neither 0 (first row) or the last row
                      || // or
                      (col == columns - 1 && (row > 0 && row < rows - 1)) // the right border 
                      )
                    {
                        if (col == 0) // left border
                            fGrid.FieldGridArray[row, col] = "LfB";
                        else // right border
                            fGrid.FieldGridArray[row, col] = "RgB";
                        continue; // go-to next cycle jail, or add a tile where it shouldn't be 
                    }

                    // if you rechead this point, it means you are not anywhere in the upper row, lower row, first column nor last column
                    // so go full yolo and pick a tile randomly according ti tge dirtOrStone flag
                    fGrid.FieldGridArray[row, col] = dirtOrStone ? "ST"+random.Next(0,5):"DR"+random.Next(0,5);

                }
            }

            return fGrid;
        }
    }
}
