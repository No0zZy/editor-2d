// See https://aka.ms/new-console-template for more information
using Krista;
using Krista.Scene;
using Krista.Views;

Console.WriteLine("Start Initialize...");

var userAction = new UserActions();

var storage = new FileStorage();
var canvasLoader = new CanvasLoader(storage);

var screenSwitcher = new ScreenSwitcher();
var menuView = new MenuView();
var canvasView = new CanvasView();
var canvasModel = new CanvasModel();

var drawModel = new FigureDrawModel();
var drawManager = new DrawManager(canvasView, canvasModel);

var scenesModel = new ScenesModel();
var canvasScene = new CanvasScene(userAction, drawManager, drawModel, canvasLoader, canvasModel);
var menuScene = new MenuScene(screenSwitcher, scenesModel, canvasModel, userAction, canvasLoader, menuView, canvasView);
var sceneLoader = new SceneLoader(scenesModel, menuScene, canvasScene, userAction);

var inputSystem = new InputSystem(userAction, canvasModel);

var initialSceneId = 0;

scenesModel.InvokeLoadScene(SceneType.Menu);
screenSwitcher.SwitchScreen(menuView);

Console.WriteLine("Initialize end. Ready.\n" +
                  "Commands:\n" +
                  "Q - create new canvas\n" +
                  "W - load random saved canvas\n" +
                  "E - draw current figure" +
                  "R - undo draw\n" +
                  "T - redo draw\n" +
                  "Y - save current canvas\n" +
                  "U - change figure to random\n" +
                  "I - change line color to random\n" +
                  "O - change line width to random");

while (inputSystem.IsReadInputs)
{
    inputSystem.ReadKey();
    inputSystem.CurrentCommand.Execute();
}

sceneLoader.Dispose();