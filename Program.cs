using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace FileCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "[1] Create", "[2] Open", "[3] Rename", "[4] Edit", "[5] Delete"};
            int opt, createOpt;
            bool invalidOption, clear;

            List<string> list = new List<string>();

            do
            {
                Console.WriteLine("FILE CREATION");
                clear = false;

                foreach (string i in options)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("[6] Show Current Files");

                do
                {
                    invalidOption = false;

                    Console.Write("\nSelect an option: ");
                    opt = Convert.ToInt16(Console.ReadLine());

                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("\nCreate a Folder/Text File:");
                            Console.WriteLine("[1] Folder \n[2] Text File \n[3] Back");

                            Console.Write("\nSelect an option: ");
                            createOpt = Convert.ToInt16(Console.ReadLine());

                            if (createOpt == 1)
                            {
                                Console.Write("\nEnter a name: ");
                                string folderName = Console.ReadLine();
                                list.Add(folderName);

                                Console.WriteLine("Folder created succesfully!");
                                clear = ClearConsole(clear);
                            }
                            else if (createOpt == 2)
                            {
                                Console.Write("\nEnter a name: ");
                                string fileName = Console.ReadLine();
                                list.Add(fileName + ".txt");

                                Console.WriteLine("Text File created succesfully!");
                                clear = ClearConsole(clear);
                            }
                            else if (createOpt == 3)
                            {
                                clear = ClearConsole(clear);
                            }
                            break;
                        case 2:
                            Console.WriteLine("\nOpen a Folder/Text File:");
                            //Files shown below
                            break;
                        case 3:
                            Console.WriteLine("\nRename a Folder/Text File:");
                            //Files shown below
                            break;
                        case 4:
                            Console.WriteLine("\nEdit a Text File:");
                            //Files shown below
                            break;
                        case 5:
                            Console.WriteLine("\nDelete a Folder/Text File:");
                            //Files shown below
                            break;
                        case 6:
                            Console.WriteLine("\nCurrent Files in YourFiles\\" + /*current folder*/ ":");
                            //Files shown below
                            foreach(string i in list)
                            {
                                Console.WriteLine("- " + i);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Option!");
                            invalidOption = true;
                            break;
                    }
                } while (invalidOption != false);
            } while (clear != false);
        }

        //methods
        static bool ClearConsole(bool clearConsole)
        {
            Console.WriteLine("\nClearing console...");
            Thread.Sleep(3000);
            Console.Clear();

            return true;
        }
        static void ListOfFiles()
        {
            
        }
    }
}
