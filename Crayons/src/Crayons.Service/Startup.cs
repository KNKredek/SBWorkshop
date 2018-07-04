using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crayons.Communication.Events;
using Crayons.Communication.Extensions;
using Crayons.Service.EventHandlers;
using Crayons.Service.EventHandlers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;
using RawRabbit.vNext.Pipe;

namespace Crayons.Service
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRawRabbit(new RawRabbitOptions {
                ClientConfiguration = Configuration
                    .GetRabbitMqConfigurationSection()
                    .Get<RawRabbitConfiguration>()
            });

            services.AddScoped<IEventHandler<MessageSentEvent>,MessageSentEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IBusClient busClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var messageSentEventHandler = app
                .ApplicationServices
                .GetService<IEventHandler<MessageSentEvent>>();

            busClient.SubscribeAsync<MessageSentEvent>(async message => {
                await messageSentEventHandler.Handle(message);
            });
        }
    }
}
