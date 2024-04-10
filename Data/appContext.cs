using AplicacaoProdutoAPI.Models;
using Microsoft.EntityFrameworkCore;

public class appDBContext : DbContext
{
    public appDBContext(DbContextOptions<appDBContext> options)
        : base(options)
    {
    }

    public DbSet<Safra> Safras { get; set; }
    public DbSet<Atividade> Atividades { get; set; }
    public DbSet<Fazenda> Fazendas { get; set; }
    public DbSet<Talhao> Talhoes { get; set; }
    public DbSet<Produto> Produtos { get; set; } = default!;
    public DbSet<AplicacaoItens> AplicacaoItens { get; set; } = default!;
    public DbSet<Aplicacao> Aplicacoes { get; set; } = default!;

}
