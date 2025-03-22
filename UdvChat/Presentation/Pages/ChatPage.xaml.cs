using UdvChat.Presentation.ViewModels;

namespace UdvChat.Presentation.Pages;

public partial class ChatPage : ContentPage
{
	private ChatViewModel viewModel => BindingContext as ChatViewModel;

	public ChatPage(ChatViewModel chatViewModel)
	{
		InitializeComponent();

		BindingContext = chatViewModel;
        MessagesCollectionView.Loaded += MessagesCollectionView_Loaded;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.Initialize();
    }

	private void ScrollToLastMessage()
	{
        if (viewModel.Messages.Any())
        {
            MessagesCollectionView.ScrollTo(viewModel.Messages.Last(), position: ScrollToPosition.MakeVisible, animate: false);
        }
    }

    private void MessagesCollectionView_Loaded(object sender, EventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            ScrollToLastMessage();
        });
    }
}