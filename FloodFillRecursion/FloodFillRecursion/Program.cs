/*
 * Patrick Brewster
 * CST-250
 * 07/03/2026
 * Flood Fill Recursion
 * Activity 3
 */
using FloodFillRecursion.Models;
//----------------------------------------------------------------------
// Start of Main Method
//----------------------------------------------------------------------

// Declare and initialize
// Create a new BoardModel
BoardModel board = new BoardModel(20,2);

// Print the board to the console
Utility.PrintBoard(board);

// Call the flood fill method using the board
board = Utility.FloodFill(board, 0, 0);

// Print the new board
Utility.PrintBoard(board);

//----------------------------------------------------------------------
// End of Main Method
//----------------------------------------------------------------------

//----------------------------------------------------------------------
// Define a utility class
//----------------------------------------------------------------------



static class Utility
{

    /// <summary>
    /// Print the board to the console
    /// </summary>
    /// <param name="board"></param>
    public static void PrintBoard(BoardModel board)
    {
        // Make sure the color of the column numbers is white
        Console.ForegroundColor = ConsoleColor.White;

        // Start the column numbers row with a space
        Console.Write("   ");

        // Loop through the column numbers
        for (int colNum = 0; colNum < board.Size; colNum++)
        {
            Console.Write($"{colNum + 1,3}");
        }

        Console.WriteLine();
        // Loop through the rows of the board
        for (int row = 0; row < board.Size; row++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{row + 1,2} ");
            // Loop through the columns of the board
            for (int col = 0; col < board.Size; col++)
            {
                // Check if the current cell is a wall
                if (board.Grid[row, col].Contents == "W")
                {
                    // Change the text color to red
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" W ");
                }
                else if (board.Grid[row, col].Contents == "E")
                {
                    // Change the text color to white
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" . ");
                }
                else if (board.Grid[row,col].Contents == "F")
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" ~ ");
                }
                else
                {
                    Console.Write("   ");
                }
            }

            // Use a WriteLine to start a new row
            Console.WriteLine();
        }

        // End of PrintBoard method
    }
    /// <summary>
    /// Perform a flood fill algorithm on the given row and col
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    internal static BoardModel FloodFill(BoardModel board, int row, int col)
    {
        // Check if the cell is on the board
        if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
        {
            // If the cell is not on the board, end the method
            return board;
        }

        // If the cell is a wall, end the method
        if (board.Grid[row, col].Contents == "W")
        {
            return board;
        }
        // If the cell has already been filled, end the method
        else if (board.Grid[row, col].Contents == "F")
        {
            return board;
        }
        // Else, fill the cell
        else
        {
            board.Grid[row, col].Contents = "F";
        }

        // Call the flood fill method to the north
        board = FloodFill(board, row - 1, col);

        // Call the flood fill method to the east
        board = FloodFill(board, row, col + 1);

        // Call the flood fill method to the south
        board = FloodFill(board, row + 1, col);

        // Call the flood fill method to the west
        board = FloodFill(board, row, col - 1);

        // Return the board
        return board;
    } // End of FloodFill method
}