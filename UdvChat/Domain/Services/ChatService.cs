using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvChat.Domain.Entities;

namespace UdvChat.Domain.Services
{
    class ChatService : IChatService
    {
        private readonly List<ShortChatEntity> shortChats = new();
        private readonly List<ChatEntity> chats = new();
        public void AddChat(ChatEntity chat)
        {
            chats.Add(chat);
            shortChats.Add(new ShortChatEntity(chat.Id, chat.Name));
        }

        public List<ShortChatEntity> GetAllChats()
        {
            return shortChats;
        }

        public ChatEntity GetChatById(Guid id)
        {
            return chats.Find(chat => chat.Id == id)!;
        }
    }
}
