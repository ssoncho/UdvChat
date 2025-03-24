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
        List<MessageEntity> GetAllMessages(Guid chatId);
        MessageEntity SendMessage(Guid chatId, string messageText);
        MessageEntity ReceiveMessage(Guid chatId, bool isFirstMessageInChat);
    }
}
