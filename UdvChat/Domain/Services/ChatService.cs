using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvChat.Domain.Entities;
using UdvChat.Data;

namespace UdvChat.Domain.Services
{
    class ChatService : IChatService
    {
        public void AddChat(ChatEntity chat)
        {
            AppData.Chats.Add(chat);
        }

        public List<ChatEntity> GetAllChats()
        {
            return AppData.Chats;
        }

        public ChatEntity GetChatById(Guid id)
        {
            return AppData.Chats.Find(chat => chat.Id == id)!;
        }
    }
}
