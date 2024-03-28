using System.Text.Json.Serialization;
using Cine.Api;
using Cine.Application;
using Cine.Infraestructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfraestructure(builder.Configuration)
        // .AddControllers().AddJsonOptions(options =>
        // {
        //     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        // })
        ;
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

