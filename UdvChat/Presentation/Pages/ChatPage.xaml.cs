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
    private ViewTreeObserver.IOnGlobalLayoutListener keyboardListener;
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
        var activity = Platform.CurrentActivity;
        var decorView = activity.Window.DecorView;
        keyboardListener = new KeyboardListener(ScrollToLastMessage);
        decorView.ViewTreeObserver.AddOnGlobalLayoutListener(keyboardListener);

        Platform.CurrentActivity.Window.SetSoftInputMode(Android.Views.SoftInput.AdjustResize);
#endif
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
#if ANDROID
        var activity = Platform.CurrentActivity;
        var decorView = activity.Window.DecorView;

        decorView.ViewTreeObserver.RemoveOnGlobalLayoutListener(keyboardListener);
        keyboardListener = null;

        Platform.CurrentActivity.Window.SetSoftInputMode(Android.Views.SoftInput.AdjustPan);
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