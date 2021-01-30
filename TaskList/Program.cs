using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Job> tasks = new List<Job>();
            tasks.Add(new Job("Wendi", "Code a task manager", "Monday, 02/01/21", false));
            tasks.Add(new Job("Steve", "Grade Lab 6", "Monday, 02/01/21", false));

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
                        foreach(Job t in tasks)
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
                    if (userChoice == "2" || userChoice == "add task")
                    {
                        /* Prompt the user to input each piece of data (team member’s name, task
                        description, due date. (Tasks will always start incomplete--that is, completion
                        status is false.) o Instantiate a new Task with this info, then add it at the end of your List.*/
                        Console.WriteLine("Please enter the team member's name: ");
                        string taskName = Console.ReadLine();
                        Console.WriteLine("Please enter the task description: ");
                        string taskDescription = Console.ReadLine();
                        Console.WriteLine("Please enter the due date: ");
                        string dueDate = Console.ReadLine();
                        tasks.Add(new Job($"{taskName}", $"{taskDescription}", $"{dueDate}", false));

                    }
                    if (userChoice == "3" || userChoice == "delete task")
                    {
                        foreach (Job t in tasks)
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
                        Console.WriteLine("Which task would you like to delete?");
                        string input2 = Console.ReadLine();
                        int userChoice2 = Int32.Parse(input2) - 1;
                        //check if userchoice2 is in index
                        if(userChoice2 >tasks.Count() ||userChoice2<1)
                        {
                            throw new IndexOutOfRangeException();
                        }

                        tasks.RemoveAt(userChoice2 - 1);
                    }

                        if (userChoice == "4" || userChoice == "mark task complete")
                    {
                        foreach (Job t in tasks)
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
                        tasks[userChoice2].Status = true;
                        


                    }
                        if (userChoice == "5" || userChoice == "Quit")
                    {
                        goAgain = false;
                        break;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("You must enter a number from the list");
                }
                catch
                {
                    Console.WriteLine("Something went wrong, try again.");
                }
                try
                {
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
                catch
                {
                    Console.WriteLine(@"Please enter a ''y'' or a ''n'' ");
                    continue;
                }
            }

        }
    }
}
