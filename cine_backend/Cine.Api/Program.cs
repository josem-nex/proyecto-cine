using Cine.Api.Filters;
using Cine.Application;
using Cine.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfraestructure(builder.Configuration);
    // builder.Services.AddControllers(options => { options.Filters.Add<ErrorHandlingFilterAttribute>(); });
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

