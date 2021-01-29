using System;
using System.Collections.Generic;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task("Wendi", "Code a task manager", "Monday, 02/01/21", false));
            tasks.Add(new Task("Steve", "Grade Lab 6", "Monday, 02/01/21", false));

            Console.WriteLine("Welcome to the Task Manager");
            bool goAgain = true;

            while (goAgain == true)
            {
                Console.WriteLine("1. List Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Mark task Complete");
                Console.WriteLine("5. Quit");
                Console.WriteLine("What would you like to do?");
                try
                {
                    string input = Console.ReadLine();
                    string userChoice = input.ToLower().Trim();
                    if(userChoice == "1" || userChoice == "list tasks")
                    {
                        foreach(Task t in tasks)
                        {
                            Console.WriteLine($"    {tasks.IndexOf(t) + 1}. Team Member: {t.Name}");
                            Console.WriteLine($"    Task Description: {t.Description}");
                            Console.WriteLine($"    Task Due Date: {t.DueDate}");
                            if (t.Status == true)
                            {
                                Console.WriteLine("     Task Status: Complete");
                            }
                            else
                            {
                                Console.WriteLine("    Task Status: Incomplete");
                            }
                            
                        }
                    }
                    if (userChoice == "4" || userChoice == "mark task complete")
                    {
                        foreach (Task t in tasks)
                        {
                            Console.WriteLine($"    {tasks.IndexOf(t) + 1}.Team Member: {t.Name}");
                            Console.WriteLine($"    Task Description: {t.Description}");
                            Console.WriteLine($"    Task Due Date: {t.DueDate}");
                            if (t.Status == true)
                            {
                                Console.WriteLine("    Task Status: Complete");
                            }
                            else
                            {
                                Console.WriteLine("    Task Status: Incomplete");
                            }
                        }
                        Console.WriteLine("Which task would you like to mark complete?");
                        string input2 = Console.ReadLine();
                        int userChoice2 = Int32.Parse(input2) -1;

                        Console.WriteLine($"{userChoice2}");


                    }
                        if (userChoice == "5" || userChoice == "Quit")
                    {
                        goAgain = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong, try again.");
                }
                Console.WriteLine("\n\nWould you like to continue?(y/n)");
                char answer = char.Parse(Console.ReadLine());
                if (char.ToLower(answer) == 'y')
                {
                    goAgain = true;
                }
                else
                {
                    goAgain = false;
                }

            }

        }
    }
}
