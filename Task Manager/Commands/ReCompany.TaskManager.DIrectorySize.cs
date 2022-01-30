using System;
using System.IO;
using System.Linq;

namespace Task_Manager
{
    internal sealed class DirectorySize
    {
        public static void Directory_Size()  // Информация про папку
        {
            try
            {
                Console.WriteLine("Введите адресс папки, информацию о которой хотите узнать: ");
                var answer = Console.ReadLine();
                var files = Directory.EnumerateFiles(answer);
                long sum = (from file in files let fileInfo = new FileInfo(file) select fileInfo.Length).Sum();
                Console.WriteLine(answer + "    Размер: " + sum + " bytes" +
                                                                  "   Дата создания: " + Directory.GetCreationTime($@"{answer}"));
            }
            catch
            {
                Console.WriteLine("Адресс введён неверно");
            }
        }
    }
}
