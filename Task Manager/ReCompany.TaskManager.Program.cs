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
                        CopyFile.Copy_File();
                        break;
                    case "ls":
                        DirInfo.Tree();
                        break;
                    case "rmd":
                        DeleteDirect.DeleteDir();
                        break;
                    case "rmf":
                        DeleteFile.Delete_File();
                        break;
                    case "fileinfo":
                        FileSize.File_Size();
                        break;
                    case "dirinfo":
                        DirectorySize.Directory_Size();
                        break;
                    case "help":
                        Help.Helping();
                        break;
                    default:
                        Console.WriteLine("Комманда не верна, попробуйте ещё раз)");
                        break;
                }
                SaveData.Save();
            }
        }
    }
}