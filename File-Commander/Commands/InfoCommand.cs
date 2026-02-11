using File_Commander.Interfaces;

namespace File_Commander.Commands
{
    internal class InfoCommand : ICommand
    {
        public string Name => "info";
        public string Description => "Показать информацию о файле. Использование: info <путь>";

        public void Execute(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Ошибка: Укажите путь к файлу.");
                return;
            }

            string path = args[0];

            if (File.Exists(path))
            {
                var fileInfo = new FileInfo(path);
                Console.WriteLine("--- Информация о файле ---");
                Console.WriteLine($"Имя:    {fileInfo.Name}");
                Console.WriteLine($"Размер: {fileInfo.Length} байт");
                Console.WriteLine($"Создан: {fileInfo.CreationTime}");
                Console.WriteLine($"Изменен: {fileInfo.LastWriteTime}");
                Console.WriteLine($"Атрибуты: {fileInfo.Attributes}");
            }
            else if (Directory.Exists(path))
            {
                // Бонус: если это папка, покажем инфу о папке
                var dirInfo = new DirectoryInfo(path);
                Console.WriteLine("--- Информация о папке ---");
                Console.WriteLine($"Имя: {dirInfo.Name}");
                Console.WriteLine($"Создана: {dirInfo.CreationTime}");
                Console.WriteLine($"Файлов внутри: {dirInfo.GetFiles().Length}");
            }
            else
            {
                Console.WriteLine($"Ошибка: Файл или папка '{path}' не найдены.");
            }
        }
    }
}
