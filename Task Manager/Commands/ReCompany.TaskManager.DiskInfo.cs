using System;
using System.IO;

namespace Task_Manager
{
    internal class DirInfo
    {
        public static void Tree()   //Отрытие дерева диска 
        {
            try
            {
                Console.WriteLine("Введите диск или адресс папки: ");
                var answer = Console.ReadLine();
                var directory = new string[] { };
                directory = Directory.GetFileSystemEntries($@"{answer}");
                for (int i = 0; i < directory.Length; i++)
                {
                    Console.WriteLine(directory[i] + @$"    
                                                        {Directory.GetCreationTime(directory[i])}");
                }
                Console.WriteLine("__________________________________________________________________");
                Console.WriteLine("__________________________________________________________________");
            }
            catch
            {
                Console.WriteLine("Адресс введён неверно");
            }
        }
    }
}
