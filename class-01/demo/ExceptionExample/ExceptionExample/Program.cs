using System;
using static System.Console;

namespace ExceptionExample
{
    class Program
    {
        static void NotMain(string[] args)
        {
            CatchSingleException();
            CatchDoubleException();
            FinallyBlockExample();
        }

        /// <summary>
        /// Method to demo how to catch a single exception
        /// </summary>
        public static void CatchSingleException()
        {
            // This is the basic layout of a Try/Catch statement.
            // we can start out with just a generic Exception in a catch. 
            int milesDriven, gallonsOfGas, mpg;
            Console.WriteLine("Hello World!");

            try
            {
                Console.WriteLine("Enter Miles Driven ");
                milesDriven = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter gallons of gas purchased ");
                gallonsOfGas = Convert.ToInt32(Console.ReadLine());
                mpg = milesDriven / gallonsOfGas;

            }
            catch (Exception e)
            {
                mpg = 0;
                Console.WriteLine(e.Message);
                throw;
            }

            Console.WriteLine($"You got {mpg} miles per gallon");
        }

        public static void CatchDoubleException()
        {
            // Point of this exercise is to show that you will get an error 
            // for both dividing by zero, and putting 
            // an item in an index within an array that does not exist. 

            // We can get more specific on the types of errors we want to catch. 
            // There is more than just generic Exception

            // If we switch the catch statements around, only the first one gets hit.
            // Talk about the generic Exception that does a catch all. that should not ever be the first error 
            // in a multi catch statement. 

            int num = 13, denom = 0, result;
            int[] array = { 22, 33, 44 };
            try
            {
                result = num / denom;
                result = array[num];
            }
            catch (DivideByZeroException error)
            {
                Console.WriteLine("We are in the first catch block");
                Console.WriteLine(error.Message);
                throw;
            }
            catch (IndexOutOfRangeException error)
            {
                Console.WriteLine("We are in the second catch block");
                Console.WriteLine(error.Message);


            }

        }

        public static void FinallyBlockExample()
        {
            try
            {
                //Statements that might cause an exception

                //Example: Open the File
                // Read the File
                // Do some sort of logic, and display the output of the file (we will go through this on day3)

            }
            catch
            {
                // What you do about it

                // Issue an error message
                // exit

            }
            finally
            {
                // statements here execute whether an exception occurred or not. 
                // if the file is open...close it. 
            }
        }


    }
}
