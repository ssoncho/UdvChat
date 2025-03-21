using UdvChat.Presentation.ViewModels;

namespace UdvChat.Presentation.Pages;

public partial class ChatListPage : ContentPage
{
    private ChatListViewModel viewModel => BindingContext as ChatListViewModel;

    public ChatListPage(ChatListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.Initialize();
    }
}