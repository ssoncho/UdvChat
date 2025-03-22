using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvChat.Data;
using UdvChat.Domain.Entities;

namespace UdvChat.Domain.Services
{
    public class MessageService : IMessageService
    {
        public (MessageEntity senderMessage, MessageEntity recipientMessage) SendMessage(Guid chatId, string messageText)
        {
            var chat = AppData.Chats.Find(chat => chat.Id == chatId);
            var sender = AppData.Users[UserTypes.Default];
            var recipient = AppData.Users[UserTypes.Robot];
            var senderMessage = new MessageEntity(sender, messageText);

            var random = new Random();
            var randomPhrase = AppData.Phrases[random.Next(AppData.Phrases.Count)];
            var recipientMessage = new MessageEntity(recipient, randomPhrase);

            chat.Messages.Add(senderMessage);
            chat.Messages.Add(recipientMessage);
            return (senderMessage, recipientMessage);
        }

        public List<MessageEntity> GetAllMessages(Guid chatId)
        {
            var chat = AppData.Chats.Find(chat => chat.Id == chatId);
            return chat.Messages;
        }

        public MessageEntity GetLastMessage(Guid chatId)
        {
            var chat = AppData.Chats.Find(chat => chat.Id == chatId);
            return chat.Messages.Last();
        }
    }
}
