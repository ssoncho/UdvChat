using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UdvChat.Domain.Entities;
using UdvChat.Domain.Services;
using UdvChat.Presentation.Pages;

namespace UdvChat.Presentation.ViewModels
{
    public partial class ChatListViewModel : ObservableObject
    {
        private readonly IPopupService _popupService;
        private readonly IChatService _chatService;

        [ObservableProperty]
        private ObservableCollection<ShortChatEntity> chats;

        public ChatListViewModel(IPopupService popupService, IChatService chatService)
        {
            _popupService = popupService;
            _chatService = chatService;
        }

        public void Initialize()
        {
            Chats = _chatService.GetAllChats().ToObservableCollection();
        }

        [RelayCommand]
        private async Task ShowPopup()
        {
            await _popupService.ShowPopupAsync<CreateChatViewModel>();
        }

        [RelayCommand]
        private void NavigateToChat(Guid chatId)
        {
            Shell.Current.GoToAsync($"{nameof(ChatPage)}?Id={chatId}");
        }
    }
}
