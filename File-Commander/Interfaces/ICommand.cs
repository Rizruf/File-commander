namespace File_Commander.Interfaces
{
    internal interface ICommand
    {
        string Name { get; }

        string Description { get; }

        void Execute(string[] args);
    }
}
