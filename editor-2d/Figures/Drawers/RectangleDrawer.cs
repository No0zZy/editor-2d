namespace Krista
{
    public class RectangleDrawer : IFigureDrawer
    {
        public void Draw(FigureData data)
        {
            Console.WriteLine($"Draw rectangle: startPos {data.InputData.StartPosition} endPos {data.InputData.EndPosition} " +
                              $"Width {data.DrawModel.LineWidth} {data.DrawModel.LineColor}");
        }
    }
}