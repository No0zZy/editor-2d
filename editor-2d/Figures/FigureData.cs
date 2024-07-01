namespace Krista
{
    [Serializable]
    public class FigureData
    {
        public InputData InputData 
        {
            get => _inputData;
            set => _inputData = value;
        }
        public FigureDrawModel DrawModel 
        {
            get => _drawModel;
            set => _drawModel = value;
        }

        private InputData _inputData;
        private FigureDrawModel _drawModel;
    }
}