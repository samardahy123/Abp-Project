using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace CoursesAppMVC;

public class CoursesAppMVCWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<CoursesAppMVCWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
