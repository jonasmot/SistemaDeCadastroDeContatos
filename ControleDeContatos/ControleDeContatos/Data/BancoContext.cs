using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) //injetamos nossa informação do BancoCntext no DbContext
        {
        }
        public DbSet<ContatoModel> Contatos { get; set; }

    }
}
