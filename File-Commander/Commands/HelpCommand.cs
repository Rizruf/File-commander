using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Commander.Interfaces;

namespace File_Commander.Commands
{
    internal class HelpCommand : ICommand
    {
        public string Name => "help";
        public string Description => "Показать список команд";

        public void Execute(string[] args)
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("help - Помощь");
            Console.WriteLine("ls/dir - Информация о содержании пространства");
        }
    }
}