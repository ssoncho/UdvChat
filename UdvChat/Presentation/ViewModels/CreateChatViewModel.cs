using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UdvChat.Domain.Entities;
using UdvChat.Domain.Services;
using UdvChat.Presentation.Pages;

namespace UdvChat.Presentation.ViewModels
{
    public partial class CreateChatViewModel : ObservableObject
    {
        [ObservableProperty]
        string chatName = "";

        private readonly IPopupService _popupService;
        private readonly IChatService _chatService;

        public CreateChatViewModel(IPopupService popupService, IChatService chatService)
        {
            _popupService = popupService;
            _chatService = chatService;
        }

        [RelayCommand]
        private async Task Cancel()
        {
            await _popupService.ClosePopupAsync();
        }

        [RelayCommand]
        private async Task Create()
        {
            if (string.IsNullOrWhiteSpace(ChatName))
                return;

            var newChatId = Guid.NewGuid();
            var newChat = new ChatEntity(newChatId, ChatName);
            _chatService.AddChat(newChat);

            await _popupService.ClosePopupAsync();
            await Shell.Current.GoToAsync($"{nameof(ChatPage)}?Id={newChatId}");
        }
    }
}
