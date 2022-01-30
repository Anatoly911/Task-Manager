using System;
using System.IO;

namespace Task_Manager
{
    internal class CopyFile
    {
        public static void Copy_File() // Копирование файла
        {
            try
            {
                Console.WriteLine("Введите путь файла, который хотите скопировать: ");
                string sourceFileName = Console.ReadLine();
                Console.WriteLine("Введите путь, куда хотите скопировать: ");
                string targetFileName = Console.ReadLine();
                File.Copy(@$"{sourceFileName}", @$"{targetFileName}");
                Console.WriteLine("Файл упешно скопирован");
            }
            catch
            {
                Console.WriteLine("Адресс введён неверно");
            }
        }
    }
}
