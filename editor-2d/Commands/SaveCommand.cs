using Krista;

namespace editor2d.Commands;

public class SaveCommand : ICommand
{
    private readonly UserActions _userActions;

    public SaveCommand(UserActions userActions)
    {
        _userActions = userActions;
    }

    public void Execute()
    {
        _userActions.InvokeSaveCanvas();
        Console.WriteLine($"Save current canvas");
    }
}