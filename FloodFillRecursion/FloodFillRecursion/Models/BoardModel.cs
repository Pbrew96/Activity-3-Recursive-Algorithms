/*
 * Patrick Brewster
 * CST-250
 * 07/03/2026
 * Flood Fill Recursion
 * Activity 3
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FloodFillRecursion.Models
{
    internal class BoardModel
    {
        // BoardModel Properties
        public int Size { get; set; }

        public CellModel[,] Grid { get; set; }

        public int NumShapes { get; set; }

        /// <summary>
        /// Parameterized constructor for BoardModel
        /// </summary>
        /// <param name="size"></param>
        public BoardModel(int size, int numShapes)
        {
            Size = size;
            NumShapes = numShapes;
            Grid = new CellModel[Size, Size];

            // Set up the Grid
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new CellModel(row, col, "E");
                }
            }
            // Place random shapes on the board
            PlaceShapes();
        }
        /// <summary>
        ///  Create shapes to place on the board
        /// </summary>
        /// <summary>
        /// Place random wall points on the board
        /// </summary>
        private void PlaceShapes()
        {
            // Declare and initialize
            Random random = new Random();
            int row = 0, col = 0;

            // Create random wall points
            for (int point = 0; point < NumShapes; point++)
            {
                // Generate a random row and column
                row = random.Next(0, Size);
                col = random.Next(0, Size);

                // Place a wall at the random location
                Grid[row, col].Contents = "W";
            }
        }

    } // End of PlaceShapes method
    }
