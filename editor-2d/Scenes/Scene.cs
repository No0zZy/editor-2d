namespace Krista.Scene
{
    public class Scene : IInitializable, IDisposable
    {
        public void Initialize()
        {
            OnInitializeInternal();
        }

        public void Dispose()
        {
            OnDisposeInternal();
        }

        protected virtual void OnInitializeInternal() { }
        protected virtual void OnDisposeInternal() { }
    }
}