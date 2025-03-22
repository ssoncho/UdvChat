using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdvChat.Domain.Entities;
using UdvChat.Resources.Strings;

namespace UdvChat.Data
{
    public static class AppData
    {
        public static List<ChatEntity> Chats = new();
        public static Dictionary<UserTypes, UserEntity> Users = new() 
        {
            { UserTypes.Default, new UserEntity(Strings.DefaultUserName) },
            { UserTypes.Robot, new UserEntity(Strings.RobotName) }
        };
        public static List<string> Phrases = [Strings.FirstPhrase, Strings.SecondPhrase, Strings.ThirdPhrase];
    }
}
