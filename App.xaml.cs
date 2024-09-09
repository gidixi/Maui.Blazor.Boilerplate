using Maui.Blazor.Boilerplate.Helpers;

namespace Maui.Blazor.Boilerplate
{
    public partial class App : Application
    {
        private readonly AuthService? _authService;
        private readonly SettingsService _settingsService;
        private readonly AppState _appState;
        public App(AuthService authService, SettingsService settingsService, AppState appState)
        {
            InitializeComponent();
            _authService = authService;
            _settingsService = settingsService;
            _appState = appState;

            MainPage = new MainPage();

            Task.Run(async () => await AutoLoginAsync());
            _settingsService = settingsService;
            _appState = appState;
        }

        private async Task AutoLoginAsync()
        {
            throw new NotImplementedException();
        }
    }
}
