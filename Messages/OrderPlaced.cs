using NServiceBus;
using System;

namespace Messages
{
    public class OrderPlaced : IEvent
    {
        public string OrderId { get; set; }
    }
}
