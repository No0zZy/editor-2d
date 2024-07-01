using Krista;

namespace editor2d.Commands;

public class RedoCommand : ICommand
{
    private readonly UserActions _userActions;

    public RedoCommand(UserActions userActions)
    {
        _userActions = userActions;
    }

    public void Execute()
    {
        _userActions.InvokeRedoDraw();
    }
}