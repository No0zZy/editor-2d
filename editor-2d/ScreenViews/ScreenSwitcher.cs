namespace Krista.Views
{
    public class ScreenSwitcher
    {
        private IScreenView _currentScreen;

        public void SwitchScreen(IScreenView screenView)
        {
            Console.WriteLine($"Switch screen to {screenView.GetType()}");

            _currentScreen?.Hide();
            _currentScreen = screenView;
            _currentScreen.Show();
        }
    }
}