using UdvChat.Presentation.Pages;

namespace UdvChat
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ChatListPage), typeof(ChatListPage));
            Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
        }
    }
}
