namespace Krista
{
    public class LineDrawer : IFigureDrawer
    {
        public void Draw(FigureData data)
        {
            Console.WriteLine($"Draw line: startPos {data.InputData.StartPosition} endPos {data.InputData.EndPosition} " +
                              $"Width {data.DrawModel.LineWidth} {data.DrawModel.LineColor}");
        }
    }
}