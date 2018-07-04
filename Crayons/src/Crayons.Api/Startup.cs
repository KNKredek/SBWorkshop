using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crayons.Api.EventDispatchers;
using Crayons.Api.EventDispatchers.Interfaces;
using Crayons.Communication.Events;
using Crayons.Communication.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Configuration;
using RawRabbit.vNext;
using RawRabbit.vNext.Pipe;

namespace Crayons.Api
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddMvc ();
            services.AddRawRabbit(new RawRabbitOptions {
                ClientConfiguration = Configuration
                    .GetRabbitMqConfigurationSection()
                    .Get<RawRabbitConfiguration>()
            });

            services.AddScoped<IEventDispatcher<MessageSentEvent>,MessageSentEventDispatcher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            app.UseMvc ();
        }
    }
}