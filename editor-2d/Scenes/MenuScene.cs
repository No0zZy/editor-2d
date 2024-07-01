using Krista.Views;

namespace Krista.Scene
{
    public class MenuScene : Scene
    {
        private readonly UserActions _userActions;
        private readonly CanvasLoader _canvasLoader;
        private readonly MenuView _menuView;
        private readonly CanvasModel _canvasModel;
        private readonly ScenesModel _scenesModel;
        private readonly CanvasView _canvasView;
        private readonly ScreenSwitcher _screenSwitcher;

        public MenuScene(ScreenSwitcher screenSwitcher, ScenesModel scenesModel, CanvasModel canvasModel,
            UserActions userActions, CanvasLoader canvasLoader, MenuView menuView, CanvasView canvasView)
        {
            _screenSwitcher = screenSwitcher;
            _scenesModel = scenesModel;
            _canvasModel = canvasModel;
            _userActions = userActions;
            _canvasLoader = canvasLoader;
            _menuView = menuView;
            _canvasView = canvasView;
        }

        protected override void OnInitializeInternal()
        {
            LoadSavedCanvases();

            _userActions.CreateNewCanvas += OnCreateNewCanvas;
            _userActions.LoadCanvas += OnLoadCanvas;
        }

        protected override void OnDisposeInternal()
        {
            _userActions.CreateNewCanvas -= OnCreateNewCanvas;
            _userActions.LoadCanvas -= OnLoadCanvas;
        }

        private void LoadSavedCanvases()
        {
            var canvases = _canvasLoader.GetSavedCanvases();
            _menuView.AddCanvases(canvases);
        }

        private void OnCreateNewCanvas()
        {
            OnLoadCanvas(new Canvas());
        }

        private void OnLoadCanvas(Canvas canvas)
        {
            _canvasModel.CurrentCanvas = canvas;

            _scenesModel.InvokeLoadScene(SceneType.Canvas);
            _screenSwitcher.SwitchScreen(_canvasView);
        }
    }
}