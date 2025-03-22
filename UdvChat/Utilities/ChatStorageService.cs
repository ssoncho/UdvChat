using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using UdvChat.Domain.Entities;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace UdvChat.Utilities
{
    public class ChatStorageService
    {
        private readonly string _filePath;

        public ChatStorageService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "chats.json");
        }

        public void SaveChats(List<ChatEntity> chats)
        {
            var json = JsonConvert.SerializeObject(chats, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public List<ChatEntity> LoadChats()
        {
            if (File.Exists(_filePath))
            {
                var json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<ChatEntity>>(json);
            }
            return new List<ChatEntity>();
        }
    }
}
