using Krista.Views;

namespace Krista
{
    public class DrawManager
    {
        private const int MaxActionsCount = 10;

        private readonly Stack<FigureData> _undoDraws = new Stack<FigureData>(MaxActionsCount);

        private readonly Dictionary<FigureType, IFigureDrawer> _drawers;

        private readonly CanvasView _canvasView;
        private readonly CanvasModel _canvasModel;

        public DrawManager(CanvasView canvasView, CanvasModel canvasModel)
        {
            _canvasView = canvasView;
            _canvasModel = canvasModel;
            _drawers = new Dictionary<FigureType, IFigureDrawer>()
            {
                {FigureType.Line, new LineDrawer()},
                {FigureType.Circle, new CircleDrawer()},
                {FigureType.Rectangle, new RectangleDrawer()}
            };
        }

        public void UndoDraw()
        {
            var drawnFigure = _canvasModel.CurrentCanvas.DrawnFigures.Last();

            _canvasModel.CurrentCanvas.DrawnFigures.Remove(drawnFigure);
            _undoDraws.Push(drawnFigure);

            RedrawCanvas();
        }

        public void RedoDraw()
        {
            if (_undoDraws.Count <= 0)
                return;

            var drawData = _undoDraws.Pop();

            AddFigureToDraw(drawData);
        }

        public void RedrawCanvas()
        {
            _canvasView.Clear();
            foreach (var drawData in _canvasModel.CurrentCanvas.DrawnFigures)
            {
                DrawFigure(drawData);
            }
        }

        public void AddNewFigureToDraw(FigureData figureData)
        {
            _undoDraws.Clear();

            AddFigureToDraw(figureData);
        }

        private void AddFigureToDraw(FigureData figureData)
        {
            _canvasModel.CurrentCanvas.DrawnFigures.Add(figureData);
            DrawFigure(figureData);
        }

        private void DrawFigure(FigureData figureData)
        {
            var drawer = _drawers[figureData.DrawModel.FigureType];
            drawer.Draw(figureData);
        }
    }
}