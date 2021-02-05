using MassInmemoryTransport.DataAccess;
using MassInmemoryTransport.Messages.Contracts;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassInmemoryTransport.Messages.Components
{
    public class ItemCreatedSalesDatabaseConsumer : IConsumer<ItemCreated>
    {
        private IRepository _repo;

        public ItemCreatedSalesDatabaseConsumer(IRepository repo)
        {
            _repo = repo;
        }

        public Task Consume(ConsumeContext<ItemCreated> context)
        {
            Console.Out.WriteLineAsync(@$"Sales-ItemAdded Consumer: Id: {context.Message.Id}, 
                itemId: {context.Message.ItemId},
                code: {context.Message.Code}, 
                desc: {context.Message.Description}");

            _repo.DoAnything();

            Console.Out.WriteLineAsync($"Coming up, adding item to sales database ...");

            return Task.CompletedTask;
        }
    }


}
