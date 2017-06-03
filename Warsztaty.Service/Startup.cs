using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawRabbit;
using RawRabbit.vNext;
using Warsztaty.Messages.Commands;
using Warsztaty.Service.Framework;
using Warsztaty.Service.Handlers;

namespace Warsztaty.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            ConfigureRabbitMq(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            ConfigureHandlers(app);
            app.UseMvc();
        }

        private void ConfigureRabbitMq(IServiceCollection services)
        {
            var options = new RabbitMqOptions();
            var section = Configuration.GetSection("rabbitmq");
            section.Bind(options);
            services.Configure<RabbitMqOptions>(section);

            var client = BusClientFactory.CreateDefault(options);
            services.AddSingleton(client);
            services.AddSingleton<IBusClient>(client);
            services.AddScoped<ICommandHandler<CreateRecord>, CreateRecordHandler>();
        }

        private void ConfigureHandlers(IApplicationBuilder app)
        {
            var client = app.ApplicationServices.GetService<IBusClient>();
            client.SubscribeAsync<CreateRecord>(
                (msg, ctx) => app.ApplicationServices.GetService<ICommandHandler<CreateRecord>>().HandleAsync(msg));
        }
    }
}