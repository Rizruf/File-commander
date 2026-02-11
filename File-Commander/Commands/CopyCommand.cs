using File_Commander.Interfaces;

namespace File_Commander.Commands
{
    internal class CopyCommand : ICommand
    {
        public string Name => "cp";
        public string Description => "Копирует файл или папку. Использование: cp <откуда> <куда>";

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Ошибка: Укажите источник и назначение.");
                return;
            }

            string source = args[0];
            string target = args[1];

            bool isSourceDir = Directory.Exists(source);
            bool isSourceFile = File.Exists(source);

            if (!isSourceDir && !isSourceFile)
            {
                Console.WriteLine($"Ошибка: Источник '{source}' не найден.");
                return;
            }

            if (Directory.Exists(target) || File.Exists(target))
            {
                Console.WriteLine($"Ошибка: Цель '{target}' уже существует!");
                return;
            }

            try
            {
                if (isSourceFile)
                {
                    File.Copy(source, target);
                    Console.WriteLine($"Файл скопирован: {target}");
                }
                else
                {
                    Console.WriteLine("Копирование папки... Это может занять время.");
                    CopyDirectory(source, target, recursive: true);
                    Console.WriteLine($"Папка успешно скопирована: {target}");
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Ошибка: Нет прав доступа.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}