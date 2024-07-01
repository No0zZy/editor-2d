using System.Drawing;

namespace Krista.Scene
{
    public class CanvasScene : Scene
    {
        private readonly UserActions _userActions;
        private readonly DrawManager _drawManager;
        private readonly FigureDrawModel _drawModel;
        private readonly CanvasLoader _canvasLoader;
        private readonly CanvasModel _canvasModel;

        public CanvasScene(UserActions userActions, DrawManager drawManager, FigureDrawModel drawModel,
            CanvasLoader canvasLoader, CanvasModel canvasModel)
        {
            _userActions = userActions;
            _drawManager = drawManager;
            _drawModel = drawModel;
            _canvasLoader = canvasLoader;
            _canvasModel = canvasModel;
        }

        protected override void OnInitializeInternal()
        {
            _userActions.UndoDraw += _drawManager.UndoDraw;
            _userActions.RedoDraw += _drawManager.RedoDraw;
            _userActions.MouseUpAction += OnMouseUpAction;
            _userActions.SaveCanvas += OnSaveCanvas;
            _userActions.ChangeFigureType += OnChangeFigureType;
            _userActions.ChangeLineColor += OnChangeLineColor;
            _userActions.ChangeLineWidth += OnChangeLineWidth;

            _drawManager.RedrawCanvas();
        }

        protected override void OnDisposeInternal()
        {
            _userActions.UndoDraw -= _drawManager.UndoDraw;
            _userActions.RedoDraw -= _drawManager.RedoDraw;
            _userActions.MouseUpAction -= OnMouseUpAction;
            _userActions.SaveCanvas -= OnSaveCanvas;
            _userActions.ChangeFigureType -= OnChangeFigureType;
            _userActions.ChangeLineColor -= OnChangeLineColor;
            _userActions.ChangeLineWidth -= OnChangeLineWidth;
        }

        private void OnMouseUpAction(InputData inputData)
        {
            var figureData = new FigureData
            {
                InputData = inputData,
                DrawModel = _drawModel.Clone(),
            };

            _drawManager.AddNewFigureToDraw(figureData);
        }

        private void OnSaveCanvas()
        {
            _canvasLoader.AddCanvasToSave(_canvasModel.CurrentCanvas);
        }

        private void OnChangeLineWidth(int width)
        {
            _drawModel.LineWidth = width;
        }

        private void OnChangeLineColor(Color color)
        {
            _drawModel.LineColor = color;
        }

        private void OnChangeFigureType(FigureType figureType)
        {
            _drawModel.FigureType = figureType;
        }
    }
}