namespace MassInmemoryTransport
{
    public class MyMassConfigSteps
    {
        // step 1
        /// <summary>
        /// works however not able to inject dependencies into consumers
        /// </summary>
        /// <param name="services"></param>
        //private static void ConfigureMasstransit(IServiceCollection services)
        //{
        //    var inMemorybus = Bus.Factory.CreateUsingInMemory(sbc =>
        //    {
        //        sbc.ReceiveEndpoint("items_queue", ep =>
        //        {
        //            ep.Handler<ItemCreated>(context =>
        //            {
        //                return Console.Out.WriteLineAsync($"Instant Consumer, received: code is {context.Message.Code}, desc is {context.Message.Description}");
        //            });
        //
        //            ep.Consumer<ItemCreatedSalesConsumer>();
        //            ep.Consumer<ItemCreatedPurchasingConsumer>();
        //        });
        //    });
        //
        //    services.AddMassTransit(config =>
        //    {
        //        config.AddBus(provider => inMemorybus);
        //    });
        //
        //    services.AddSingleton<IBus>(inMemorybus);
        //}

        // step 1.1
        //private static void ConfigureMasstransit(IServiceCollection services)
        //{
        //    var inMemorybus = Bus.Factory.CreateUsingInMemory(sbc =>
        //    {
        //        sbc.ReceiveEndpoint("items_queue", ep =>
        //        {
        //            ep.Consumer<ItemCreatedSalesConsumer>();
        //            ep.Consumer<ItemCreatedPurchasingConsumer>();
        //        });
        //    });
        //
        //    services.AddMassTransit(config =>
        //    {
        //        config.AddBus(provider => inMemorybus);
        //    });
        //
        //    // instead of holding a reference and add it to services: services.AddSingleton<IBus>(inMemorybus);
        //    // it can also be retrieved from IServiceProvider by type and then add it to services like this:
        //    services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
        //}


        // step 2
        /// <summary>
        /// this works with asp.net core di, so i am able to inject some dependencey into a consumer
        /// </summary>
        /// <param name="services"></param>
        //private static void ConfigureMasstransit(IServiceCollection services)
        //{
        //    services.AddMassTransit(config =>
        //    {
        //        config.AddConsumersFromNamespaceContaining<ItemCreatedSalesConsumer>();
        //        //config.AddConsumer<ItemCreatedSalesConsumer>();
        //        //config.AddConsumer<ItemCreatedSalesDatabaseConsumer>();
        //        config.UsingInMemory((context, cfg) =>
        //        {
        //            cfg.ReceiveEndpoint("item_definition_queue", ep =>
        //            {
        //                ep.Handler<ItemCreated>(context =>
        //                {
        //                    return Console.Out.WriteLineAsync($"Instant Consumer, received: code is {context.Message.Code}, desc is {context.Message.Description}");
        //                });
        //
        //                ep.ConfigureConsumer<ItemCreatedSalesDatabaseConsumer>(context);
        //                ep.ConfigureConsumer<ItemCreatedSalesConsumer>(context);
        //                ep.ConfigureConsumer<ItemCreatedPurchasingConsumer>(context);
        //
        //
        //            });
        //        });
        //    });
        //
        //    services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
        //}


    }
}
