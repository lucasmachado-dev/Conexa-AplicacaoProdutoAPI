using AplicacaoProdutoAPI.Repositories.Interfaces;
using AplicacaoProdutoAPI.Repositories;
using AplicacaoProdutoAPI.Services.Interfaces;
using AplicacaoProdutoAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AplicacaoProdutoAPI
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<appDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("appDBContext") ?? throw new InvalidOperationException("Connection string 'appDBContext' not found.")));

            services.AddScoped<IAplicacaoRepository, AplicacaoRepository>();
            services.AddScoped<IAtividadeRepository, AtividadeRepositoty>();
            services.AddScoped<IFazendaRepository, FazendaRepositoty>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ITalhaoRepository, TalhaoRepository>();
            services.AddScoped<ISafraRepository, SafraRepository>();

            services.AddScoped<IAplicacaoService, AplicacaoService>();
            services.AddScoped<IAtividadeService, AtividadeService>();
            services.AddScoped<IFazendaService, FazendaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ISafraService, SafraService>();
            services.AddScoped<ITalhaoService, TalhaoService>();
            

            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
