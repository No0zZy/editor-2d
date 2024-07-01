using Krista;

namespace editor2d.Commands;

public class ChangeFigureCommand : ICommand
{
    private readonly UserActions _userActions;

    private FigureType[] _figureTypes = new[]
    {
        FigureType.Circle,
        FigureType.Line,
        FigureType.Rectangle
    };

    public ChangeFigureCommand(UserActions userActions)
    {
        _userActions = userActions;
    }

    public void Execute()
    {
        var random = new Random();
        var figure = _figureTypes[random.Next(_figureTypes.Length)];

        _userActions.SwitchFigure(figure);

        Console.WriteLine($"Change figure to {figure}");
    }
}