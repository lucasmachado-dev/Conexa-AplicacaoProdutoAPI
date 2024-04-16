using AplicacaoProdutoAPI;
using AplicacaoProdutoAPI.Repositories;
using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Services;
using AplicacaoProdutoAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

/*TODO: Criar um model básico (Id, Descricao) para ser herdado nas classes mais básicas.
 * Implementar validações nos services
 * Implementar service/repository genérico para operações básicas
 * Implementar busca avançada de aplicações, permitindo buscar por safra, fazenda, período e atividade
*/


var builder = WebApplication.CreateBuilder(args);


ServiceConfiguration.ConfigureServices(builder.Services, builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<appDBContext>();
    dbContext.Database.Migrate();
}

app.Run();
