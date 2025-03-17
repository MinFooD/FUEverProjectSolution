namespace FueverProject.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentationLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
    }
}