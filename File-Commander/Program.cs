using File_Commander.Commands;
using File_Commander.Core;
using File_Commander.Interfaces;

namespace File_Commander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new CommandManager().Run();
        }
    }
}
