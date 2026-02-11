using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File_Commander.Interfaces;
using File_Commander.Commands;

namespace File_Commander.Commands
{
    internal class LsCommand : ICommand
    {
        public string Name => "dir";
        public string Description => "Информация о содержании пространства";

        public void Execute(string[] args)
        {
            string getCurrendDir = Directory.GetCurrentDirectory();

            string[] dirs = Directory.GetDirectories(getCurrendDir);
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            foreach (var dir in dirs)
            {
                Console.WriteLine($"[DIR] {Path.GetFileName(dir)}");
            }

            string[] files = Directory.GetFiles(getCurrendDir);
            Console.ForegroundColor = ConsoleColor.White;
            
            foreach (var file in files)
            {
                Console.WriteLine($"      {Path.GetFileName(file)}");
            }

            Console.ResetColor();
        }
    }
}
