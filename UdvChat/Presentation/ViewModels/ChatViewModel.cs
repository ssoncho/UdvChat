using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using UdvChat.Domain.Entities;
using UdvChat.Domain.Services;

namespace UdvChat.Presentation.ViewModels
{

    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class ChatViewModel : ObservableObject
    {
        private readonly IChatService _chatService;

        private Guid chatId;
        public string Id { get; set; }

        [ObservableProperty]
        private ChatEntity chat;

        public ChatViewModel(IChatService chatService)
        {
            _chatService = chatService;
        }

        public void Initialize()
        {
            if (Id != null)
            {
                chatId = Guid.Parse(Id);
                Chat = _chatService.GetChatById(chatId);
            }
        }
    }
}
