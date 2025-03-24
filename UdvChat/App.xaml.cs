using UdvChat.Data;
using UdvChat.Utilities;

namespace UdvChat
{
    public partial class App : Application
    {
        private readonly ChatStorageService _chatStorageService = new();

        public App()
        {
            InitializeComponent();
            LoadData();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override void OnStart()
        {
            base.OnStart();
            LoadData();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            SaveData();
        }

        protected override void OnResume()
        {
            base.OnResume();
            LoadData();
        }

        private void LoadData()
        {
            AppData.Chats = _chatStorageService.LoadChats();
        }

        private void SaveData()
        {
            _chatStorageService.SaveChats(AppData.Chats);
        }
    }
}