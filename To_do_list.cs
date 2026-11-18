using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace To_do_list
{
    internal class To_do_list
    {
        static void Main(string[] args)
        {
            // Create the list
            List<string> toDoList = new List<string>();

            // Add activities to the list
            Console.WriteLine("Write down your tasks for today. Type 'done' when you are ready.");
            while (true)
            {
                string userInput = Console.ReadLine().ToLower();
                toDoList.Add(userInput);

                if (userInput.ToLower() == "done")
                {
                    break;
                }
            }

            toDoList.Remove("done");
            toDoList.RemoveAll(s => s == null || s.Length == 0);

            // Check completed and note it
            Console.WriteLine("\nSo, here is your to-do list:");
            for (int i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {toDoList[i]}");
            }


            Console.WriteLine("\nWhat to do next?");
            Console.WriteLine("1. Add something to the list");
            Console.WriteLine("2. Remove something from the list");
            Console.WriteLine("3. Mark something as ready");
            int userChoice;
            while(true)
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (userChoice < 4 && userChoice > 0)
                {
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine("Okay, what would you like to add? Type 'done' when you are ready.");
                            int count = toDoList.Count;
                            while (true)
                            {
                                string userAddChoice = Console.ReadLine().ToLower();
                                toDoList.Add(userAddChoice);

                                if (userAddChoice.ToLower() == "done")
                                {
                                    break;
                                }
                            }
                            toDoList.Remove("done");
                            toDoList.RemoveAll(s => s == null || s.Length == 0);
                            int newCount = toDoList.Count;
                            Console.WriteLine($"\nYou have added {newCount - count} new element(s) to your to-do list. Here is how it looks like now:");
                            for (int i = 0; i < toDoList.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {toDoList[i]}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Okay, what would you like to remove?");
                            int userRemoveChoice;
                            while (true)
                            {
                                try
                                {
                                    userRemoveChoice = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    continue;
                                }
                                if (userRemoveChoice <= toDoList.Count && userRemoveChoice > 0)
                                {
                                    Console.WriteLine($"Remove \"{toDoList[userRemoveChoice -1]}\" from your to-do list? (Y)es / (N)o");
                                    string userConfirmation = Console.ReadLine();
                                    while (true)
                                    {
                                        if (userConfirmation.ToLower() != "y" && userConfirmation.ToLower() != "n")
                                        {
                                            Console.WriteLine("Wrong input. Please try again.");
                                            userConfirmation = Console.ReadLine();
                                            continue;
                                        }
                                        break;
                                    }
                                    if (userConfirmation.ToLower() == "y")
                                    {
                                        toDoList.Remove(toDoList[userRemoveChoice - 1]);
                                        Console.WriteLine("\nDone! Here is your updated to-do list:");
                                        for (int i = 0; i < toDoList.Count; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {toDoList[i]}");
                                        }
                                    }
                                    else if (userConfirmation.ToLower() == "n")
                                    {
                                        Console.WriteLine("Alright, what would it be then?");
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is no such element in your to-do list. Please try again.");
                                    continue;
                                }
                                break;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Okay, what is done?");
                            int userDoneChoice;
                            while (true)
                            {
                                try
                                {
                                    userDoneChoice = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    continue;
                                }
                                if (userDoneChoice <= toDoList.Count && userDoneChoice > 0)
                                {
                                    toDoList[userDoneChoice - 1] += " - done";
                                    foreach (string toDo in toDoList)
                                    {
                                        Console.WriteLine(toDo);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("There is no such element in your to-do list. Please try again.");
                                    continue;
                                }
                                break;
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("No such an option. Please try again.");
                    continue;
                }
                break;
            }

            // Show message when all is done

            Console.ReadLine();
        }
    }
}
