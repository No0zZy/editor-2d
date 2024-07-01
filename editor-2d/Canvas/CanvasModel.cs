namespace Krista;

public class CanvasModel
{
    public Canvas CurrentCanvas { get; set; }
    public List<Canvas> SavedCanvases { get; } = new List<Canvas>();

    public void AddCanvases(IEnumerable<Canvas> canvases)
    {
        SavedCanvases.AddRange(canvases);
    }
}