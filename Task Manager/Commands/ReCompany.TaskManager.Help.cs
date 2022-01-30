using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    internal sealed class Help
    {
        public static void Helping()
        {
            Console.WriteLine(@"
             cp - копирование файла
             ls - показ дерева папки или диска.
             rmd - удаление папки
             rmf - удаление файла
             fileinfo - показывает информацию о файле
             dirinfo - показывает информацию о папке");
        }
    }
}
