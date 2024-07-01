using System.Drawing;

namespace Krista
{
    [Serializable]
    public class FigureDrawModel
    {
        public FigureType FigureType
        {
            get => _figureType;
            set => _figureType = value;
        }
        public Color LineColor
        {
            get => _lineColor;
            set => _lineColor = value;
        }
        public int LineWidth
        {
            get => _lineWidth;
            set => _lineWidth = value;
        }

        private FigureType _figureType = FigureType.Line;
        private Color _lineColor = Color.Black;
        private int _lineWidth = 1;

        public FigureDrawModel Clone()
        {
            return new FigureDrawModel()
            {
                FigureType = _figureType,
                LineColor = _lineColor,
                LineWidth = _lineWidth
            };
        }
    }
}