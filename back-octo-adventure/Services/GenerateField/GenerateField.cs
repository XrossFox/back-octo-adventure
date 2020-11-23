using back_octo_adventure.Models.FieldMatrix;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_octo_adventure.Services.GenerateField
{
    public class GenerateField : IGenerateField
    {

        private IConfiguration configurator;

        /// <summary>
        /// Base constructor receiver an IConfiguration instance to allow access to map.json config file.
        /// </summary>
        /// <param name="config"></param>
        public GenerateField(IConfiguration config) {

            configurator = config;
        }

        public FieldGrid GenerateFieldGrid(int rows, int columns)
        {
            FieldGrid fGrid = new FieldGrid();

            fGrid.FieldGridArray = new string[rows][];

            // if bool is false, then terrain will be stone, else will be dirt.
            Random random = new Random();
            bool floorTilesetType = random.Next(0, 1) == 0? true: false;

            for (int row = 0; row < fGrid.FieldGridArray.GetLength(0); row++) {

                fGrid.FieldGridArray[row] = new string[columns];

                for (int col = 0; col < fGrid.FieldGridArray[row].GetLength(0); col++) {

                    // if it's a upper corner tile, either left or right
                    if ((row == 0 && col == 0) || (row == 0 && col == columns - 1))
                    {
                        // its the left one
                        if (col == 0)
                            fGrid.FieldGridArray[row][col] = configurator["CornerUpLeft"];
                        // its the right one
                        else
                            fGrid.FieldGridArray[row][col] = configurator["CornerUpRight"];
                        continue; // go-to next cycle jail, or add a tile where it shouldn't be 
                    }

                    // if it's a lower corner tile, either left or right
                    if ((row == rows - 1 && col == 0) || (row == rows - 1 && col == columns - 1))
                    {
                        // left
                        if (col == 0)
                            fGrid.FieldGridArray[row][col] = configurator["CornerDownLeft"];
                        else
                            fGrid.FieldGridArray[row][col] = configurator["CornerDownRight"];
                        continue;
                    }

                    // if it's the upper row, but not the corners
                    if ((row == 0) && (col > 0 && col < columns - 1))
                    {
                        fGrid.FieldGridArray[row][col] = configurator["BorderUpMid"];
                        continue; // go-to next cycle jail, or add a tile where it shouldn't be 
                    }

                    // if it's the lower row, but not the corners
                    if ((row == rows - 1) && (col > 0 && col < columns - 1))
                    {
                        fGrid.FieldGridArray[row][col] = configurator["BorderDownMid"];
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
                            fGrid.FieldGridArray[row][col] = configurator["BorderLeft"];
                        else // right border
                            fGrid.FieldGridArray[row][col] = configurator["BorderRight"];
                        continue; // go-to next cycle jail, or add a tile where it shouldn't be 
                    }

                    // if you rechead this point, it means you are not anywhere in the upper row, lower row, first column nor last column
                    // so go full yolo and pick a tile randomly according ti tge dirtOrStone flag
                    fGrid.FieldGridArray[row][col] = floorTilesetType ?
                        configurator["FloorTileSets:DirtTileSet:{tileN}".Replace("{tileN}", random.Next(1, 5).ToString())] :
                        configurator["FloorTileSets:StoneTileSet:{tileN}".Replace("{tileN}", random.Next(1, 5).ToString())];
                }
            }

            return fGrid;
        }
    }
}
