using File_Commander.Interfaces;

namespace File_Commander.Commands
{
    internal class DeleteCommand : ICommand
    {
        public string Name => "rm";
        public string Description => "Удаляет файл или папку. Использование: rm <путь>";

        public void Execute(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Ошибка: Укажите путь к файлу или папке.");
                return;
            }

            string path = args[0];

            bool isDir = Directory.Exists(path);
            bool isFile = File.Exists(path);

            if (!isDir && !isFile)
            {
                Console.WriteLine($"Ошибка: '{path}' не найден.");
                return;
            }

            Console.Write($"Вы уверены, что хотите удалить '{path}'? [y/n]: ");
            string answer = Console.ReadLine();
            if (answer?.ToLower() != "y")
            {
                Console.WriteLine("Отмена.");
                return;
            }

            try
            {
                if (isDir)
                {
                    Directory.Delete(path, recursive: true);
                    Console.WriteLine($"Папка '{path}' удалена.");
                }
                else
                {
                    File.Delete(path);
                    Console.WriteLine($"Файл '{path}' удален.");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Ошибка: Нет прав доступа (попробуй запустить от Админа).");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
            }
        }
    }
}