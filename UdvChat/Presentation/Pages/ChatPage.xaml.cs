using UdvChat.Presentation.ViewModels;

namespace UdvChat.Presentation.Pages;

public partial class ChatPage : ContentPage
{
	private ChatViewModel viewModel => BindingContext as ChatViewModel;

	public ChatPage(ChatViewModel chatViewModel)
	{
		InitializeComponent();

		BindingContext = chatViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.Initialize();
    }
}