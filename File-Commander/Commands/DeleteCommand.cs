using File_Commander.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Commander.Commands
{
    internal class DeleteCommand : ICommand
    {
        public string Name => "rm";

        public string Description => "Удаление файла. Использование: rm <файл>";

        public void Execute(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Ошибка: нужен 1 аргумент");
                return;
            }

            var sourcePath = args[0];

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Такого фаила не существует!");
                return;
            }

            Console.Write($"Удалить {sourcePath}? [y/n]: ");
            string answer = Console.ReadLine();
            if (answer.ToLower() != "y") return;

            try
            {
                File.Delete(sourcePath);
                Console.WriteLine($"Успешно удалено: {sourcePath}");
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
