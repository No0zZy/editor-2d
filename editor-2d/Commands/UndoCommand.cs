using Krista;

namespace editor2d.Commands;

public class UndoCommand : ICommand
{
    private readonly UserActions _userActions;

    public UndoCommand(UserActions userActions)
    {
        _userActions = userActions;
    }

    public void Execute()
    {
        _userActions.InvokeUndoDraw();
    }
}