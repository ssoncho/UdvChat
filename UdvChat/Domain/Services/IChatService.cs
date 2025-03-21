using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvChat.Domain.Entities;

namespace UdvChat.Domain.Services
{
    public interface IChatService
    {
        List<ShortChatEntity> GetAllChats();
        ChatEntity GetChatById(Guid id);
        void AddChat(ChatEntity chat);
    }
}
