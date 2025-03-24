using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdvChat.Domain.Entities
{
    public record ChatEntity(Guid Id, string Name)
    {
        public List<MessageEntity> Messages { get; } = new();
        public MessageEntity LastMessage => Messages.LastOrDefault();
    }
}
