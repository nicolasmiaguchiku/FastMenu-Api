using FoodManager.Catalog.CrossCutting.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;

namespace FoodManager.Catalog.CrossCutting.Extentions
{
    public static class SerilogExtensions
    {
        public static IApplicationBuilder UseRequestContextLogging(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestContextLoggingMiddleware>();
            app.UseSerilogRequestLogging(options =>
            {
                options.GetLevel = (httpContext, elapsed, ex) =>
                {
                    var statusCode = httpContext.Response.StatusCode;

                    if (statusCode >= 500)
                    {
                        return Serilog.Events.LogEventLevel.Error;
                    }
                    else if (statusCode >= 400)
                    {
                        return Serilog.Events.LogEventLevel.Warning;
                    }
                    else
                    {
                        return Serilog.Events.LogEventLevel.Information;
                    }
                };

                options.MessageTemplate =
                    "HTTP {RequestMethod} {RequestPath} -> {StatusCode} in {Elapsed:0}ms";
            });


            return app;
        }

        public static IHostBuilder UseSerilog(this IHostBuilder builder, string serviceName, string seqUrl)
        {
            builder.UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration
                    .ReadFrom.Configuration(context.Configuration)
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                    .Enrich.WithProperty("ServiceName", serviceName)
                    .Enrich.WithExceptionDetails();

                if (context.HostingEnvironment.IsDevelopment())
                {
                    loggerConfiguration
                        .MinimumLevel.Debug()
                        .WriteTo.Console(outputTemplate:
                            "{Timestamp:yyyy-MM-dd HH:mm:ss} | {Level} | CorrelationId:{CorrelationId} | RequestPath:{RequestPath} | Env:{Environment} | {SourceContext} | {Message} | {Exception}{NewLine}")
                        .WriteTo.Seq(seqUrl);
                }
                else
                {
                    loggerConfiguration
                        .MinimumLevel.Information()
                        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                        .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
                        .MinimumLevel.Override("System.Net.Http.HttpClient", Serilog.Events.LogEventLevel.Warning)
                        .WriteTo.Console(outputTemplate:
                            "{Timestamp:yyyy-MM-dd HH:mm:ss} | {Level} | CorrelationId:{CorrelationId} | RequestPath:{RequestPath} | Env:{Environment} | {SourceContext} | {Message} | {Exception}{NewLine}")
                        .WriteTo.Seq(seqUrl);
                }
            });

            return builder;
        }
    }
}