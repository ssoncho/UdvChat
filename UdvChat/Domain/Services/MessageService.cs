using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvChat.Data;
using UdvChat.Domain.Entities;
using UdvChat.Resources.Strings;

namespace UdvChat.Domain.Services
{
    public class MessageService : IMessageService
    {
        public MessageEntity SendMessage(Guid chatId, string messageText)
        {
            var sender = AppData.Users[UserTypes.Default];
            var message = CreateMessage(chatId, sender, messageText);
            return message;
        }

        public MessageEntity ReceiveMessage(Guid chatId, bool isFirstMessageInChat)
        {
            string messageText;
            if (isFirstMessageInChat)
            {
                messageText = Strings.HelloPhrase;
            }
            else
            {
                var random = new Random();
                messageText = AppData.Phrases[random.Next(AppData.Phrases.Count)];
            }
            var sender = AppData.Users[UserTypes.Robot];
            var message = CreateMessage(chatId, sender, messageText);
            return message;
        }

        public List<MessageEntity> GetAllMessages(Guid chatId)
        {
            var chat = AppData.Chats.Find(chat => chat.Id == chatId);
            return chat.Messages;
        }

        private MessageEntity CreateMessage(Guid chatId, UserEntity sender, string messageText)
        {
            var chat = AppData.Chats.Find(chat => chat.Id == chatId);
            var message = new MessageEntity(sender, messageText);
            chat.Messages.Add(message);
            return message;
        }
    }
}
