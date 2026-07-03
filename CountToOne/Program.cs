/*
 * Patrick Brewster
 * CST-250
 * 07/03/2026
 * Count To One Recursion
 * Activity 3
 */


//------------------------------------------------------------------
// Start of Main Method
//------------------------------------------------------------------

// Declare and initialize
int choice = 0, result = 0, steps = 0;
string input = "";

// Prompt the user for a number
Console.Write("Enter a number: ");

// Get the user's input
input = Console.ReadLine();

// See if the user entered a valid input
while (!int.TryParse(input, out choice))
{
    Console.WriteLine("Invalid number");

    // Re-prompt the user
    Console.Write("Enter a number: ");

    // Get the user's input
    input = Console.ReadLine();
}

// Call the CountToOne function
result = Utility.CountToOne(choice, ref steps);

Console.WriteLine($"The end number is {result}");
Console.WriteLine($"It took {steps} recursive calls.");


//------------------------------------------------------------------
// End of Main Method
//------------------------------------------------------------------


static class Utility
{
    /// <summary>
    /// Count to one using recursion.
    /// </summary>
    /// <param name="num"></param>
    /// <param name="steps"></param>
    /// <returns></returns>
    internal static int CountToOne(int num, ref int steps)
    {
        // Count this recursive call
        steps++;

        // Print the current number
        Console.WriteLine($"The current number is {num}");

        // Check if the number is 1
        if (num == 1)
        {
            return 1;
        }

        // Handle zero
        if (num == 0)
        {
            Console.WriteLine("The number is 0. Add 1");
            return CountToOne(num + 1, ref steps);
        }

        // Handle negative numbers
        if (num < 0)
        {
            Console.WriteLine("The number is negative. Add 1");
            return CountToOne(num + 1, ref steps);
        }

        // Divide by 4 if possible
        if (num % 4 == 0)
        {
            Console.WriteLine("The number is divisible by 4. Divided by 4");
            return CountToOne(num / 4, ref steps);
        }

        // Divide by 3 if possible
        if (num % 3 == 0)
        {
            Console.WriteLine("The number is divisible by 3. Divided by 3");
            return CountToOne(num / 3, ref steps);
        }

        // Divide by 2 if even
        if ((num % 2) == 0)
        {
            Console.WriteLine("The number is even. Divided by 2");
            return CountToOne(num / 2, ref steps);
        }

        // Special condition for numbers divisible by 5
        if (num % 5 == 0)
        {
            Console.WriteLine("The number is divisible by 5. Multiply by 2 then subtract 1");
            return CountToOne((num * 2) - 1, ref steps);
        }

        // Number is odd
        Console.WriteLine("The number is odd. Subtract 1");
        return CountToOne(num - 1, ref steps);
    }
}