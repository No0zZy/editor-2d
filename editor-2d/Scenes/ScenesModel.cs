namespace Krista.Scene;

public class ScenesModel
{
    public event Action<SceneType> LoadScene;

    public void InvokeLoadScene(SceneType sceneType)
    {
        LoadScene?.Invoke(sceneType);
    }
}