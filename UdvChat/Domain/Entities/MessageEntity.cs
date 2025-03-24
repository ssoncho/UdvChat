using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvChat.Domain.Entities
{
    public record MessageEntity(UserEntity User, string Text)
    {
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
