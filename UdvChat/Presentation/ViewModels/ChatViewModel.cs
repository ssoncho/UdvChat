using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UdvChat.Domain.Entities;
using UdvChat.Domain.Services;

namespace UdvChat.Presentation.ViewModels
{

    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class ChatViewModel : ObservableObject
    {
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;

        private Guid chatId;
        public string Id { get; set; }

        [ObservableProperty]
        private ChatEntity chat;
        [ObservableProperty]
        private string newMessageText = "";

        [ObservableProperty]
        private ObservableCollection<MessageEntity> messages;

        public ChatViewModel(IChatService chatService, IMessageService messageService)
        {
            _chatService = chatService;
            _messageService = messageService;
        }

        public void Initialize()
        {
            if (Id != null)
            {
                chatId = Guid.Parse(Id);
                Chat = _chatService.GetChatById(chatId);
                Messages = _messageService.GetAllMessages(chatId).ToObservableCollection();

                if (Chat.LastMessage == null)
                {
                    var message = _messageService.ReceiveMessage(chatId, true);
                    Messages.Add(message);
                }
            }
        }

        [RelayCommand]
        private async Task SendMessage()
        {
            if (string.IsNullOrEmpty(NewMessageText))
                return;
            var senderMessage = _messageService.SendMessage(chatId, NewMessageText);
            NewMessageText = "";
            Messages.Add(senderMessage);

            await Task.Delay(1000);
            var recipientMessage = _messageService.ReceiveMessage(chatId, false);
            Messages.Add(recipientMessage);
        }
    }
}
