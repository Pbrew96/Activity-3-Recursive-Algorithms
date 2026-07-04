/*
 * Patrick Brewster
 * CST-250
 * 07/03/2026
 * Greatest Common Divisor Recursion
 * Activity 3
 */

using System.Diagnostics;

//-------------------------------------------------------------------------------
// Start of the Main Method
//-------------------------------------------------------------------------------

// Declare and initialize
int number1 = 0, number2 = 0, number3 = 0;
int recursiveResult = 0, iterativeResult = 0, multipleResult = 0;

Stopwatch stopwatch = new Stopwatch();

// Prompt the user
Console.Write("Enter the first number: ");
number1 = Utility.ReadIntFromConsole();

Console.Write("Enter the second number: ");
number2 = Utility.ReadIntFromConsole();

Console.Write("Enter the third number: ");
number3 = Utility.ReadIntFromConsole();

// Make negative numbers positive
number1 = Math.Abs(number1);
number2 = Math.Abs(number2);
number3 = Math.Abs(number3);

// Solve using recursion
Console.WriteLine("\nSolving the GCD using recursion...");
stopwatch.Start();
recursiveResult = Utility.GreatestCommonDivisor(number1, number2);
stopwatch.Stop();

Console.WriteLine($"The recursive GCD of {number1} and {number2} is {recursiveResult}");
Console.WriteLine($"Recursive Time: {stopwatch.ElapsedTicks} ticks");

// Reset the stopwatch
stopwatch.Reset();

// Solve using iteration
Console.WriteLine("\nSolving the GCD using iteration...");
stopwatch.Start();
iterativeResult = Utility.GreatestCommonDivisorIterative(number1, number2);
stopwatch.Stop();

Console.WriteLine($"The iterative GCD of {number1} and {number2} is {iterativeResult}");
Console.WriteLine($"Iterative Time: {stopwatch.ElapsedTicks} ticks");

// Solve using three numbers
multipleResult = Utility.GreatestCommonDivisor(recursiveResult, number3);

Console.WriteLine($"\nThe GCD of {number1}, {number2}, and {number3} is {multipleResult}");

//-------------------------------------------------------------------------------
// End of the Main Method
//-------------------------------------------------------------------------------


//-------------------------------------------------------------------------------
// Start of the Utility Class
//-------------------------------------------------------------------------------
public class Utility
{
    /// <summary>
    /// Read an integer from the console.
    /// </summary>
    /// <returns></returns>
    internal static int ReadIntFromConsole()
    {
        // Declare and initialize
        string input = "";
        int number = 0;

        // Get the current input
        input = Console.ReadLine();

        // Check if the input is valid
        while (!int.TryParse(input, out number))
        {
            // Show the user an error message and prompt them again
            Console.WriteLine("Invalid input. Please try again: ");

            // Get the new input
            input = Console.ReadLine();
        }

        // Return the resulting integer from the user
        return number;
    }

    /// <summary>
    /// Calculate the GCD using recursion.
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    internal static int GreatestCommonDivisor(int num1, int num2)
    {
        // Base case: num2 is 0
        if (num2 == 0)
        {
            // Return the greatest common divisor
            return num1;
        }
        else
        {
            // Declare and initialize
            int remainder = 0;

            // Get the remainder of dividing num1 and num2
            remainder = num1 % num2;

            // Print an update to the user
            Console.WriteLine($"Not yet. The remainder of {num1} and {num2} is {remainder}");

            // Call the recursive function with the second number and the remainder
            return GreatestCommonDivisor(num2, remainder);
        }
    }

    /// <summary>
    /// Calculate the GCD using iteration.
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    internal static int GreatestCommonDivisorIterative(int num1, int num2)
    {
        // Handle zero values
        if (num1 == 0)
        {
            return num2;
        }

        if (num2 == 0)
        {
            return num1;
        }
        // Declare and initialize
        List<int> divisors1 = new List<int>();
        List<int> divisors2 = new List<int>();
        int gcd = 1;

        // Find divisors for the first number
        for (int i = 1; i <= num1; i++)
        {
            if (num1 % i == 0)
            {
                divisors1.Add(i);
            }
        }

        // Find divisors for the second number
        for (int i = 1; i <= num2; i++)
        {
            if (num2 % i == 0)
            {
                divisors2.Add(i);
            }
        }

        // Find the largest divisor in both lists
        foreach (int divisor in divisors1)
        {
            if (divisors2.Contains(divisor))
            {
                gcd = divisor;
            }
        }

        // Return the greatest common divisor
        return gcd;
    }
}