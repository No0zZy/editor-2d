using System.Numerics;
using Krista;

namespace editor2d.Commands;

public class DrawCommand : ICommand
{
    private readonly UserActions _userActions;

    public DrawCommand(UserActions userActions)
    {
        _userActions = userActions;
    }
    
    public void Execute()
    {
        var random = new Random();
        var startPos = new Vector2(random.Next(10));
        var endPos = new Vector2(random.Next(10));

        _userActions.MouseDown(startPos);
        _userActions.MouseUp(endPos);
    }
}