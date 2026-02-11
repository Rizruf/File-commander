using File_Commander.Interfaces;

namespace File_Commander.Commands
{
    internal class HelpCommand : ICommand
    {
        public string Name => "help";
        public string Description => "Показать список команд";

        public void Execute(string[] args)
        {
            Console.WriteLine("\n Доступные команды: \n");
            Console.WriteLine("1. help - Помощь\n");
            Console.WriteLine("2. rm/del - Удаление файла\n");
            Console.WriteLine("4. info - Информация о файле\n");
            Console.WriteLine("4. cp - Копирование файла\n");
            Console.WriteLine("5. dir/ls - Информация о содержании пространства папок и файлов\n");
        }
    }
}