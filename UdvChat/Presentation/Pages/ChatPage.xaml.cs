using Android.Views;
using UdvChat.Presentation.ViewModels;
using Android.Views;
using Microsoft.Maui.ApplicationModel;
using UdvChat.Utilities;

namespace UdvChat.Presentation.Pages;

public partial class ChatPage : ContentPage
{
    private ChatViewModel viewModel => BindingContext as ChatViewModel;

    public ChatPage(ChatViewModel chatViewModel)
    {
        InitializeComponent();

        BindingContext = chatViewModel;
        MessagesCollectionView.Loaded += MessagesCollectionView_Loaded;
        //MessageEntry.Focused += MessageEntry_Focused;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.Initialize();
//#if ANDROID
//        Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(new KeyboardListener(ScrollToLastMessage));
//#endif
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

    private void MessageEntry_Focused(object sender, FocusEventArgs e)
    {
        Dispatcher.Dispatch(() =>
        {
            ScrollToLastMessage();
        });
    }
}