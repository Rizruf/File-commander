using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Commander.Interfaces;

namespace File_Commander.Commands
{
    internal class CopyCommand : ICommand
    {
        public string Name => "cp";

        public string Description => "Копирование файла. Использование: cp <откуда> <куда>";

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Ошибка: Меньше 2 аргументов");
                return;
            }

            var sourcePath = args[0];
            var targetPath = args[1];

            if (File.Exists(sourcePath))
            {
                Console.WriteLine("Ошибка: Фаил не найден!"); return;
            }

            try
            {
                File.Copy(sourcePath, targetPath, overwrite: true);
                Console.WriteLine($"Успешно скопировано: {sourcePath} -> {targetPath}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("У вас не достаточно прав доступа");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Ошибка ввода, файл возможно занят");
            }
        }
    }
}
