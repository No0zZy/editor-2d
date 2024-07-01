using System.Drawing;
using Krista;

namespace editor2d.Commands;

public class ChangeColorCommand : ICommand
{
    private readonly UserActions _userActions;

    private Color[] _colors = new[]
    {
        Color.Black,
        Color.Red,
        Color.Green
    };

    public ChangeColorCommand(UserActions userActions)
    {
        _userActions = userActions;
    }

    public void Execute()
    {
        var random = new Random();
        var color = _colors[random.Next(_colors.Length)];

        _userActions.SwitchLineColor(color);

        Console.WriteLine($"Change color to {color}");
    }
}