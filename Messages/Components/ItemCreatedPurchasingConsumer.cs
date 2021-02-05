using MassInmemoryTransport.Messages.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassInmemoryTransport.Messages.Components
{
    public class ItemCreatedPurchasingConsumer : IConsumer<ItemCreated>
    {
        public Task Consume(ConsumeContext<ItemCreated> context)
        {
            Console.Out.WriteLineAsync(@$"Purchasing: ItemAdded Consumer: 
                Id: {context.Message.Id}, 
                itemId: {context.Message.ItemId},
                code: {context.Message.Code}, 
                desc: {context.Message.Description}
                Now processing item......");

            return Task.CompletedTask;
        }
    }
}
