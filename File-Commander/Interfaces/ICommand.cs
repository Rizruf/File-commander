using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Commander.Interfaces
{
    internal interface ICommand
    {
        string Name { get; }

        string Description { get; }

        void Execute(string[] args);
    }
}
