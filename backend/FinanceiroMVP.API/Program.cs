var builder = WebApplication.CreateBuilder(args);

// Serviços da aplicação
builder.Services.AddOpenApi();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Financeiro MVP API em execução.");

app.Run();