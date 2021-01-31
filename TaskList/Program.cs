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

            Console.WriteLine("\nWelcome to the Task Manager\n");
            bool goAgain = true;

            while (goAgain == true)
            {
                Console.WriteLine("---Main Menu---");
                Console.WriteLine("1. List Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Mark task Complete");
                Console.WriteLine("5. Edit a task");
                Console.WriteLine("6. Quit");
                Console.WriteLine("\nPlease choose an option by entering it's number: ");
                try
                {
                    string input = Console.ReadLine();
                    string userChoice = input.ToLower().Trim();
                    if (userChoice == "1" || userChoice == "list tasks")
                    {
                        JobList(tasks);
                    }
                    if (userChoice == "2" || userChoice == "add task")
                    {
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
                        if (userChoice2 > tasks.Count() || userChoice2 < 0)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        Console.WriteLine("Are you sure you want to delete this task? (y/n)");
                        string choice = Console.ReadLine();
                        string choice2 = choice.ToLower().Trim();
                        if (choice2 == "y" || choice2 == "yes")
                        {
                            tasks.RemoveAt(userChoice2);
                            Console.WriteLine("Task deleted successfully");
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (userChoice == "4" || userChoice == "Mark task complete")
                    {
                        JobList(tasks);
                        Console.WriteLine("Which task would you like to mark complete?");
                        string input2 = Console.ReadLine();
                        int input3 = Int32.Parse(input2);
                        int userChoice2 = Int32.Parse(input2) - 1;
                        //check if userchoice2 is in index
                        if (userChoice2 > tasks.Count() || input3 < 1)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        tasks[userChoice2].Status = true;
                        Console.WriteLine($"\nTask {userChoice2 + 1} marked complete");
                        JobInfo(tasks, userChoice2);
                    }
                    if (userChoice == "5" || userChoice == "Edit a task")
                    {
                        JobList(tasks);
                        Console.WriteLine("Which task would you like to edit?");
                        string input2 = Console.ReadLine();
                        int userChoice2 = Int32.Parse(input2) - 1;
                        JobInfo(tasks, userChoice2);
                        EditMenu();
                        string input3 = Console.ReadLine();
                        int userEditChoice = Int32.Parse(input3);
                        if(userEditChoice == 1)
                        {
                            Console.WriteLine("Please enter a new task member name:");
                            string newMemberName = Console.ReadLine();
                            tasks[userChoice2].Name = newMemberName;
                            Console.WriteLine("\nName changed successfully");
                            JobInfo(tasks, userChoice2);
                        }
                        if (userEditChoice == 2)
                        {
                            Console.WriteLine("Please enter a new task description:");
                            string newDescription = Console.ReadLine();
                            tasks[userChoice2].Description = newDescription;
                            Console.WriteLine("\nDescription changed successfully");
                            JobInfo(tasks, userChoice2);
                        }
                        if (userEditChoice == 3)
                        {
                            Console.WriteLine("Please enter a new task due date:");
                            string newDueDate = Console.ReadLine();
                            tasks[userChoice2].DueDate = newDueDate;
                            Console.WriteLine("\nDue Date changed successfully");
                            JobInfo(tasks, userChoice2);
                        }
                        if (userEditChoice == 4)
                        {
                            if(tasks[userChoice2].Status == true)
                            {
                                Console.WriteLine("Task is currently marked complete. Are you sure you want to mark it incomplete?");
                                string choice = Console.ReadLine();
                                string choice2 = choice.ToLower().Trim();
                                if(choice2 == "y")
                                {
                                  tasks[userChoice2].Status= false;
                                    Console.WriteLine("Task marked incomplete successfully");
                                    JobInfo(tasks, userChoice2);
                                }
                                else if(choice2 == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(@"Please enter a ''y'' or an ''n'' ");
                                    throw new FormatException();
                                }
                            }
                            else if(tasks[userChoice2].Status == false)
                            {
                                Console.WriteLine("Task is currently marked incomplete. Are you sure you want to mark it complete?");
                                string choice = Console.ReadLine();
                                string choice2 = choice.ToLower().Trim();
                                if (choice2 == "y")
                                {
                                    tasks[userChoice2].Status = true;
                                    Console.WriteLine("Task marked complete successfully");
                                    JobInfo(tasks, userChoice2);
                                }
                            }
                        }
                    }

                    if (userChoice == "6" || userChoice == "Quit")
                        {
                            Console.WriteLine("Goodbye! Have a great day!");
                            goAgain = false;
                            break;
                        }
              
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("You must enter a number from the list");
                    Console.WriteLine();
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(@"Please enter a ""y'' or an ""n"" ");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Something went wrong, try again.");
                    Console.WriteLine();
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
                    Console.WriteLine(@"Please enter a ""y"" or an ""n"" ");
                    Console.WriteLine();
                }
            }

        }
        public static void JobList(List<Job> tasks)
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
                Console.WriteLine();
            }
        }

        public static void JobInfo(List<Job> tasks, int userChoice2)
        {
            foreach (Job t in tasks)
            {
                if (tasks.IndexOf(t) == userChoice2)
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
                Console.WriteLine();
            }
        }
        public static void EditMenu()
        {
            Console.WriteLine("---Task Edit Menu---");
            Console.WriteLine("\n1.Edit the task member name");
            Console.WriteLine("2.Edit the task description");
            Console.WriteLine("3.Edit the task due date");
            Console.WriteLine("4.Change task completion status");
            Console.WriteLine("\nPlease choose an option by entering it's number: ");

        }

    }
}
