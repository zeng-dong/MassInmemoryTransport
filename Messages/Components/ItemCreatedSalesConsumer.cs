using MassInmemoryTransport.Messages.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassInmemoryTransport.Messages.Components
{
    public class ItemCreatedSalesConsumer : IConsumer<ItemCreated>
    {
        public Task Consume(ConsumeContext<ItemCreated> context)
        {
            Console.Out.WriteLineAsync(@$"Sales-ItemAdded Consumer: Id: {context.Message.Id}, 
                itemId: {context.Message.ItemId},
                code: {context.Message.Code}, 
                desc: {context.Message.Description}");
            Console.Out.WriteLineAsync($"Coming up, adding item to sales database ...");

            return Task.CompletedTask;
        }
    }
}
