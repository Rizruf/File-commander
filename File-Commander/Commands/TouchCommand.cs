using File_Commander.Interfaces;

namespace File_Commander.Commands
{
    internal class TouchCommand : ICommand
    {
        public string Name => "touch";
        public string Description => "Создать файл (-f) или папку (-d). Пример: touch -f file.txt";

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Ошибка: Укажите флаг и имя.");
                Console.WriteLine("  touch -f <имя>  (файл)");
                Console.WriteLine("  touch -d <имя>  (папка)");
                return;
            }

            string type = args[0];
            string path = args[1];

            try
            {
                if (type == "-f")
                {
                    if (File.Exists(path))
                    {
                        Console.WriteLine("Файл уже существует.");
                        return;
                    }
                    
                    File.Create(path).Close();
                    Console.WriteLine($"Файл '{path}' создан.");
                }
                else if (type == "-d")
                {
                    if (Directory.Exists(path))
                    {
                        Console.WriteLine("Папка уже существует.");
                        return;
                    }
                    Directory.CreateDirectory(path);
                    Console.WriteLine($"Папка '{path}' создана.");
                }
                else
                {
                    Console.WriteLine("Неизвестный тип. Используйте -f (файл) или -d (папка).");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}