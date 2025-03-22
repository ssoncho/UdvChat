using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvChat.Domain.Entities;

namespace UdvChat.Domain.Services
{
    public interface IMessageService
    {
        MessageEntity GetLastMessage(Guid chatId);
        List<MessageEntity> GetAllMessages(Guid chatId);
        (MessageEntity senderMessage, MessageEntity recipientMessage) SendMessage(Guid chatId, string messageText);
    }
}
