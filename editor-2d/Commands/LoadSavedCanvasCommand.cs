using Krista;
using Krista.Views;

namespace editor2d.Commands;

public class LoadSavedCanvasCommand : ICommand
{
    private readonly UserActions _userActions;
    private readonly CanvasModel _canvasModel;

    public LoadSavedCanvasCommand(UserActions userActions, CanvasModel canvasModel)
    {
        _userActions = userActions;
        _canvasModel = canvasModel;
    }

    public void Execute()
    {
        var random = new Random();
        var canvas = _canvasModel.SavedCanvases[random.Next(_canvasModel.SavedCanvases.Count)];

        Console.WriteLine($"Load saved canvas.");

        _userActions.InvokeLoadCanvas(canvas);
    }
}