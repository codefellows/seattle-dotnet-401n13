using System;

namespace BugTesting
{
    class Program
    {
        // Main is always the "Entry Point" of the app
        // Keep the logic out of here
        static void Main(string[] args)
        {
            GetAge();
            Squares();
        }

        private static void Squares()
        {
            int[] evens = new int[3] { 2, 4, 6 };
            int[] odds = new int[3];
            odds[0] = 1;
            odds[1] = 3;
            odds[2] = 5;

            foreach (int number in evens)
            {
                // 500 lines of horrific logic
                Console.WriteLine(number * number);
            }

        }

        private static void GetAge()
        {

            try
            {
                Console.WriteLine("How old are you?");
                string input = Console.ReadLine();
                // JS: parseInt()

                // PRO: Reads like a sentence and is explicit
                // CON: Multi-Responsibility;
                // int age = Convert.ToInt32(input) + 1

                // More verbose, but explicit, and lets us capture bugs in 2 places
                int age = Convert.ToInt32(input);
                age++;

                Console.WriteLine($"Next year, you will be {age} years old!");
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"Damn, that's a lot ... {oe.Message}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"I need a number! {fe.Message}");
            }

            // Catch-All ... anything not previously captured
            catch (Exception e)
            {
                Console.WriteLine($"I'm Just lost ... {e.Message}");
            }
            // Resolves the "Try"
            finally
            {
                Console.WriteLine("We are here in the finallly block");
            }


        }
    }
}