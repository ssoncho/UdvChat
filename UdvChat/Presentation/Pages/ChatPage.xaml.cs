using Android.Views;
using UdvChat.Presentation.ViewModels;
using Android.Views;
using Microsoft.Maui.ApplicationModel;
using UdvChat.Utilities;
using Android.Content;
using Android.Views.InputMethods;
using AndroidX.Core.View;
using Microsoft.Maui.Platform;

namespace UdvChat.Presentation.Pages;

public partial class ChatPage : ContentPage
{
    private ChatViewModel viewModel => BindingContext as ChatViewModel;

    public ChatPage(ChatViewModel chatViewModel)
    {
        InitializeComponent();

        BindingContext = chatViewModel;
        MessagesCollectionView.Loaded += MessagesCollectionView_Loaded;
        MessageEditor.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == "Height")
            {
                ScrollToLastMessage();
            }
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.Initialize();
#if ANDROID
        Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(new KeyboardListener(ScrollToLastMessage));
#endif
    }

    private void ScrollToLastMessage()
    {
        if (viewModel.Messages.Any())
        {
            MessagesCollectionView.ScrollTo(viewModel.Messages.Last(), position: ScrollToPosition.End, animate: false);
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