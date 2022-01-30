using System;
using System.IO;

namespace Task_Manager
{
    internal sealed class DeleteDirect
    {
        public static string DeleteDir() // Удаление каталога
        {
            try
            {
                Console.WriteLine("Введите адресс папки, которую хотите удалить: ");
                var answers = Console.ReadLine();
                DeleteDirectory(answers);
            }
            catch
            {
                Console.WriteLine("Адресс введён неверно");
            }
            return "Папка упешно удалена";
        }
        internal static void DeleteDirectory(string target_dir) //Метод для удаления каталога рекурсивно!
        {
            try
            {
                string[] files = Directory.GetFiles(target_dir);
                string[] dirs = Directory.GetDirectories(target_dir);
                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir);
                }
                Directory.Delete(target_dir, false);
            }
            catch
            {
                Console.WriteLine("Адресс введён неверно");
            }
        }
    }
}
