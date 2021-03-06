﻿using MassInmemoryTransport.DataAccess;
using MassInmemoryTransport.Messages.Components;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MassInmemoryTransport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository, SimpleRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MassInmemoryTransport", Version = "v1" });
            });

            ConfigureMasstransit(services);
        }

        private static void ConfigureMasstransit(IServiceCollection services)
        {
            services.AddMassTransit(config =>
            {
                config.AddConsumersFromNamespaceContaining<ItemCreatedSalesConsumer>();
                config.UsingInMemory((context, cfg) => cfg.ReceiveEndpoint("item_definition_queue", ep => ep.ConfigureConsumers(context)));
            });

            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MassInmemoryTransport v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMassTransitInMemoryTransport();
        }


    }
}
