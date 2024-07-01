using System.Numerics;
using Color = System.Drawing.Color;

namespace Krista
{
    //example. in real project this events will be from many another places, like buttons
    public class UserActions
    {
        public event Action<InputData> MouseUpAction = delegate(InputData data) { };
        public event Action CreateNewCanvas;
        public event Action SaveCanvas;
        public event Action UndoDraw;
        public event Action RedoDraw;
        public event Action<Canvas> LoadCanvas;
        public event Action<int> ChangeLineWidth;
        public event Action<Color> ChangeLineColor;
        public event Action<FigureType> ChangeFigureType;
        public event Action BackToMenu;

        private InputData _currentInputData;

        public void SwitchLineWidth(int width)
        {
            ChangeLineWidth?.Invoke(width);
        }

        public void SwitchLineColor(Color color)
        {
            ChangeLineColor?.Invoke(color);
        }

        public void SwitchFigure(FigureType figureType)
        {
            ChangeFigureType?.Invoke(figureType);
        }

        public void MouseDown(Vector2 downPosition)
        {
            _currentInputData = new InputData
            {
                StartPosition = downPosition
            };
        }

        public void MouseUp(Vector2 upPosition)
        {
            _currentInputData.EndPosition = upPosition;
            MouseUpAction.Invoke(_currentInputData);
        }

        public void InvokeCreateNewCanvas()
        {
            CreateNewCanvas?.Invoke();
        }

        public void InvokeLoadCanvas(Canvas canvas)
        {
            LoadCanvas?.Invoke(canvas);
        }

        public void InvokeUndoDraw()
        {
            UndoDraw?.Invoke();
        }

        public void InvokeRedoDraw()
        {
            RedoDraw?.Invoke();
        }

        public void InvokeSaveCanvas()
        {
            SaveCanvas?.Invoke();
        }

        public void InvokeBackToMenu()
        {
            BackToMenu?.Invoke();
        }
    }
}