using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Task_Manager
{
    class Program
    {
        static void Main(string[] args)  // Список доступных команд
        {

            while (true)
            {
                Console.WriteLine(Properties.Resources.START);  // Свойство с выводом: "Введите команду" 
                string user = Console.ReadLine();
                switch (user)
                {
                    case "cp":
                        CopyFile();
                        break;
                    case "ls":
                        Tree();
                        break;
                    case "rmd":
                        DeleteDir();
                        break;
                    case "rmf":
                        DeleteFile();
                        break;
                    case "fileinfo":
                        FileLength();
                        break;
                    case "dirinfo":
                        GetDirectorySize();
                        break;
                    case "help":
                        Help();
                        break;
                    default:
                        Console.WriteLine("Комманда не верна, попробуйте ещё раз)");
                        break;
                }

                Save();
            }

        }
        static string Tree()   //Отрытие дерева диска 
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
            return "Выберите другую коммнаду";
        }
        static string CopyFile() // Копирование файла
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
            return "Выберите другую коммнаду";
        }
        static string DeleteDir() // Удаление каталога
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
            return "Папка упешно удаленау";
        }
        static void DeleteDirectory(string target_dir) //Метод для удаления каталога рекурсивно!
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
        static string DeleteFile() // удаление файла
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
        static string FileLength() //Узнать размер и атрибуты файлы
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
            return "Выберите другую коммнаду";
        }
        static void  GetDirectorySize()  // Информация про папку
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
        static string Save() // Сохранение данных в текстовый документ
        {
            Configuration roaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = roaming.FilePath };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("UserName", Console.ReadLine());
            config.Save();
            var userName = config.AppSettings.Settings["UserName"].Value;
            config.AppSettings.Settings["UserName"].Value = $"{userName}";
            config.Save();
            string User = userName;
            string json = JsonSerializer.Serialize(User);
            File.WriteAllText("config.json", json);
            return "Выберите другую команду";
        }
        static string Help()
        {
            Console.WriteLine(@"
             cp - копирование файла
             ls - показ дерева папки или диска.
             rmd - удаление папки
             rmf - удаление файла
             fileinfo - показывает информацию о файле
             dirinfo - показывает информацию о папке");

            return "Выберите другую команду";
        }
    }
}


