using System;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Task Manager");
            bool goAgain = true;

            while (goAgain = true)
            {
                Console.WriteLine("1. List Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Mark task complete");
                Console.WriteLine("5. Quit");
                Console.WriteLine("What would you like to do?");
                try
                {
                    string input = Console.ReadLine()
                    string userChoice = input.ToLower().Trim();

                    if(userChoice == "5" || userChoice == "Quit")
                    {
                        goAgain = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a number 1-5");
                }
            }

        }
    }
}
