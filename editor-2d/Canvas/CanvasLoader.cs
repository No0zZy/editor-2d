namespace Krista
{
    public class CanvasLoader
    {
        public const string CanvasesSaveKey = "canvases.save.key";

        private readonly IStorage _storage;

        private List<Canvas> _cashedCanvases = new List<Canvas>();
        private bool _isCashed;

        public CanvasLoader(IStorage storage)
        {
            _storage = storage;
        }

        public void AddCanvasToSave(Canvas canvas)
        {
            _cashedCanvases.Add(canvas);
            _storage.SaveData(CanvasesSaveKey, _cashedCanvases);
        }

        public IEnumerable<Canvas> GetSavedCanvases()
        {
            if (_isCashed) 
                return _cashedCanvases;

            try
            {
                var canvases = _storage.LoadData<List<Canvas>>(CanvasesSaveKey);
                _cashedCanvases.AddRange(canvases);
                _isCashed = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            return _cashedCanvases;
        }
    }
}