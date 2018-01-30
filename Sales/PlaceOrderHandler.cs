using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
        static Random random = new Random();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

            // This is normally where some business logic would occur

            #region ThrowTransientException
            // Uncomment to test throwing transient exceptions
            //if (random.Next(0, 5) == 0)
            //{
            //    throw new Exception("Oops");
            //}
            #endregion

            // Uncomment to test throwing fatal exceptions
            //throw new Exception("BOOM");

            var orderPlaced = new OrderPlaced
            {
                OrderId = message.OrderId
            };
            return context.Publish(orderPlaced);
        }
    }
}
