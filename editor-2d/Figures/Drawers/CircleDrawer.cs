namespace Krista
{
    public class CircleDrawer : IFigureDrawer
    {
        public void Draw(FigureData data)
        {
            Console.WriteLine($"Draw circle: startPos {data.InputData.StartPosition} endPos {data.InputData.EndPosition} " +
                              $"Width {data.DrawModel.LineWidth} {data.DrawModel.LineColor}");
        }
    }
}