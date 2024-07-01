using Krista;

namespace editor2d.Commands;

public class ChangeWidthCommand : ICommand
{
    private readonly UserActions _userActions;

    public ChangeWidthCommand(UserActions userActions)
    {
        _userActions = userActions;
    }

    public void Execute()
    {
        var random = new Random();
        var width = random.Next(10);

        _userActions.SwitchLineWidth(width);
        Console.WriteLine($"Change width to {width}");
    }
}