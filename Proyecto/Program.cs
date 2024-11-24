using Proyecto.Application.Interfaces;
using Proyecto.Application.Services;
using Proyecto.Infrastructure.Clients;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllers();

// Registrar servicios de aplicación
builder.Services.AddScoped<IChatService, ChatService>();

// Registrar clientes HTTP
builder.Services.AddHttpClient<WhatsAppClient>();
builder.Services.AddHttpClient<OpenAIClient>();

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
