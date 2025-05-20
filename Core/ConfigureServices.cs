using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Serilog;
using Serilog.Events;
using Serilog.Templates;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public class ConfigureServices
    {
        public static class DependencyInjection
        {
            public static IServiceProvider Setup()
            {
                var host = Host.CreateDefaultBuilder()
                   .ConfigureServices((_context, services) =>
                   {
                       services.UseMicrosoftDependencyResolver();
                       var resolver = Locator.CurrentMutable;
                       resolver.InitializeSplat();
                       resolver.InitializeReactiveUI();
                       services.AddSerilog(c =>
                       {
                           c.MinimumLevel.Override("Microsoft", LogEventLevel.Warning);

                           c.Filter.ByExcluding("SourceContext like 'ReactiveUI.POCOObservableForProperty' and Contains(@m, 'WhenAny will only return a single value')");
                           c.WriteTo.Map("Account", "Other", (acc, wt) =>
                           {
                               wt.File(new ExpressionTemplate("[{@t:HH:mm:ss} {@l:u3}{#if SourceContext is not null} ({SourceContext}){#end}] {@m}\n{@x}"),
                                   path: $"./logs/log-{acc}-.txt",
                                   rollingInterval: RollingInterval.Day);
                           });

                           c.Enrich.FromLogContext();
                       });
                   })
                   .UseDefaultServiceProvider(config =>
                   {
                       config.ValidateOnBuild = true;
                       config.ValidateScopes = true;
                   })
                   .Build();

                var container = host.Services;

                container.UseMicrosoftDependencyResolver();
                return container;
            }
        }
    }
}