using System.Numerics;

namespace Krista
{
    [Serializable]
    public class InputData
    {
        public Vector2 StartPosition
        {
            get => _startPosition;
            set => _startPosition = value;
        }

        public Vector2 EndPosition
        {
            get => _endPosition;
            set => _endPosition = value;
        }

        private Vector2 _startPosition;
        private Vector2 _endPosition;
    }
}