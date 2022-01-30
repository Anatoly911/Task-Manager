using System;
using System.IO;

namespace Task_Manager
{
    internal class FileSize
    {
        public static void File_Size() //Узнать размер и атрибуты файлы
        {
            try
            {
                Console.WriteLine("Введите адресс файла, информацию о котором хотите узнать: ");
                var answers = Console.ReadLine();
                FileInfo fi = new FileInfo($@"{answers}");
                Console.WriteLine("Размер файла:  " + fi.Length.ToString() + " bytes");
                Console.WriteLine("Дата создания:  " + fi.CreationTime.ToLongDateString());
                FileAttributes fileAttributes = File.GetAttributes(answers);
                Console.WriteLine(fileAttributes);
            }
            catch
            {
                Console.WriteLine("Адресс введён неверно");
            }
        }
    }
}
