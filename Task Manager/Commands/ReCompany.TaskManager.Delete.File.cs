using System;
using System.IO;

namespace Task_Manager
{
    internal class DeleteFile
    {
        public static string Delete_File() // удаление файла
        {
            try
            {
                Console.WriteLine("Введите адресс файла, который хотите удалить: ");
                var answers = Console.ReadLine();
                File.Delete(answers);
            }
            catch
            {
                Console.WriteLine("Адресс введён неверно");
            }
            return "Файл успешно удален";
        }
    }
}
