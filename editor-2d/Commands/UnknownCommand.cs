namespace editor2d.Commands;

public class UnknownCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Unknown command.");
    }
}