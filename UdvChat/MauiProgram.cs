
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using UdvChat.Domain.Services;
using UdvChat.Presentation.Pages;
using UdvChat.Presentation.ViewModels;

namespace UdvChat;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddSingleton<IChatService, ChatService>();
        builder.Services.AddSingleton<ChatListViewModel>();
        builder.Services.AddSingleton<ChatListPage>();
        builder.Services.AddTransient<ChatViewModel>();
        builder.Services.AddTransient<ChatPage>();
        builder.Services.AddTransientPopup<CreateChatPage,CreateChatViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
