using editor2d.Commands;

namespace Krista;

public class InputSystem
{
    public bool IsReadInputs { get; private set; } = true;
    
    public ICommand CurrentCommand { get; private set; }

    private readonly UserActions _userActions;
    private readonly CanvasModel _canvasModel;

    public InputSystem(UserActions userActions, CanvasModel canvasModel)
    {
        _userActions = userActions;
        _canvasModel = canvasModel;
    }

    public void ReadKey()
    {
        var input = Console.ReadKey();

        switch (input.Key)
        {
            case ConsoleKey.Q:
                CurrentCommand = new CreateCanvasCommand(_userActions);
                break;
            case ConsoleKey.W:
                CurrentCommand = new LoadSavedCanvasCommand(_userActions, _canvasModel);
                break;
            case ConsoleKey.E:
                CurrentCommand = new DrawCommand(_userActions);
                break;
            case ConsoleKey.R:
                CurrentCommand = new UndoCommand(_userActions);
                break;
            case ConsoleKey.T:
                CurrentCommand = new RedoCommand(_userActions);
                break;
            case ConsoleKey.Y:
                CurrentCommand = new SaveCommand(_userActions);
                break;
            case ConsoleKey.U:
                CurrentCommand = new ChangeFigureCommand(_userActions);
                break;
            case ConsoleKey.I:
                CurrentCommand = new ChangeColorCommand(_userActions);
                break;
            case ConsoleKey.O:
                CurrentCommand = new ChangeWidthCommand(_userActions);
                break;
            case ConsoleKey.Escape:
                IsReadInputs = false;
                break;
        }
    }
}