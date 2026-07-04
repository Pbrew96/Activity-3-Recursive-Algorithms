/*
 * Patrick Brewster
 * CST-250
 * 07/03/2026
 * Factorial Recursion
 * Activity 3
 */


using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FactorialRecursion.Services.BusinessLogicLayer
{
    public class FactorialLogic
    {

        /// <summary>
        ///  Solve the factorial problem using iteration
        /// </summary>
        /// <param name="factorial"></param>
        /// <returns></returns>
        internal BigInteger SolveIterativeFactorial(int factorial)
        {
            //Declare and initialize
            BigInteger result = 1;

            // For loop to solve the factorial
            for(int i = factorial; i >= 1; i--)
            {
                // Multiply result by i
                result *= i;
            }
            // Return the result
            return result;
        }
        internal BigInteger SolveRecursiveFactorial(int factorial)
        {
            // Base Case: factorial is 0 or 1
            if (factorial == 0 || factorial == 1)
            {
                return 1;
            }
            // Perform the recursion
            return factorial * SolveRecursiveFactorial(factorial - 1);

        }
    }
}
