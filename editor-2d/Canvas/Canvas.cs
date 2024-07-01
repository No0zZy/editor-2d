namespace Krista
{
    [Serializable]
    public class Canvas
    {
        public List<FigureData> DrawnFigures 
        {
            get => _drawnFigures;
            set => _drawnFigures = value;
        }

        private List<FigureData> _drawnFigures = new List<FigureData>();
    }
}