using Krista;

namespace editor2d.Commands;

public class CreateCanvasCommand : ICommand
{
    private readonly UserActions _userActions;

    public CreateCanvasCommand(UserActions userActions)
    {
        _userActions = userActions;
    }
    public void Execute()
    {
        Console.WriteLine($"Create new canvas.");
        _userActions.InvokeCreateNewCanvas();
    }
}