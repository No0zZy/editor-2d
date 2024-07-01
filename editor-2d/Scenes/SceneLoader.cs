namespace Krista.Scene
{
    public class SceneLoader : IDisposable
    {
        private readonly ScenesModel _scenesModel;
        private readonly UserActions _userActions;
        private readonly Dictionary<SceneType, Scene> _scenes = new Dictionary<SceneType, Scene>();

        private Scene _currentScene;

        public SceneLoader(ScenesModel scenesModel, MenuScene menuScene,
            CanvasScene canvasScene, UserActions userActions)
        {
            _scenesModel = scenesModel;
            _userActions = userActions;

            _scenes.Add(SceneType.Menu, menuScene);
            _scenes.Add(SceneType.Canvas, canvasScene);

            _scenesModel.LoadScene += LoadScene;
            _userActions.BackToMenu += OnBackToMenu;
        }

        public void Dispose()
        {
            _currentScene.Dispose();

            _scenesModel.LoadScene -= LoadScene;
            _userActions.BackToMenu -= OnBackToMenu;
        }

        private void OnBackToMenu()
        {
            LoadScene(SceneType.Menu);
        }

        private void LoadScene(SceneType sceneType)
        {
            var scene = GetSceneByType(sceneType);

            Console.WriteLine($"Loaded scene: {scene.GetType()}");

            _currentScene?.Dispose();
            _currentScene = scene;
            _currentScene.Initialize();
        }

        private Scene GetSceneByType(SceneType sceneType)
        {
            if (_scenes.ContainsKey(sceneType))
                return _scenes[sceneType];

            throw new Exception($"There is no scene with type {sceneType}.");
        }
    }
}