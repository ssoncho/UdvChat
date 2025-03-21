using CommunityToolkit.Maui.Views;
using UdvChat.Presentation.ViewModels;

namespace UdvChat.Presentation.Pages;

public partial class CreateChatPage : Popup
{
	public CreateChatPage(CreateChatViewModel createChatViewModel)
	{
		InitializeComponent();

		BindingContext = createChatViewModel;
	}
}