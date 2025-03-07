using System;
using System.Collections.Generic;

namespace FileCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "[1] Create", "[2] Open", "[3] Rename", "[4] Delete" };
            int opt, createOpt;

            List<string> list = new List<string>();

            Console.WriteLine("FILE CREATION");

            foreach(string i in options) {
                Console.WriteLine(i);
            }

            do {
                Console.Write("\nSelect an option: ");
                opt = Convert.ToInt16(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("\nCreate a Folder/Text File:");
                        Console.WriteLine("[1] Folder \n[2] Text File");
                        
                        Console.Write("\nSelect an option: ");
                        createOpt = Convert.ToInt16(Console.ReadLine());

                        if(createOpt==1)
                        {
                            Console.WriteLine("\nEnter a name: ");
                            string folderName = Console.ReadLine();
                            list.Add(folderName);

                            Console.WriteLine("Folder created succesfully!");
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
                        Console.WriteLine("\nDelete a Folder/Text File:");
                        //Files shown below
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            } while (opt < 1 || opt > 3);
        }

        //methods
        public void ClearConsole()
        {

        }
    }
}
