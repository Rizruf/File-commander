using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Commander.Commands;
using File_Commander.Interfaces;

namespace File_Commander.Core
{
    internal class CommandManager
    {
        private Dictionary <string, ICommand> _commands = new Dictionary <string, ICommand> ();

        public CommandManager()
        {
            Register(new HelpCommand());
        }

        public void Register(ICommand command)
        {
            _commands.Add(command.Name, command);
        }

        public void Run()
        {
            while (true)
            {
                Console.Write("Введите команду - ");
                string inputText = Console.ReadLine ();

                if (string.IsNullOrEmpty(inputText)) continue;

                string[] partsText = inputText.Split(' ');
                string commandName = partsText[0].ToLower();

                string[] args = partsText.Skip(1).ToArray();

                if (_commands.ContainsKey(commandName))
                {
                    _commands[commandName].Execute(args);
                }
                else
                {
                    Console.WriteLine($"Команда '{commandName}' не найдена. Введите 'help'.");
                }
            }
        }
    }
}
