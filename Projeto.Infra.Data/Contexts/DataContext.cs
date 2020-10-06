using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    //REGRA 1) Herdar DbContext
    public class DataContext : DbContext
    {
        //REGRA 2) Construtor para receber a connectionstring do banco
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        //REGRA 3) Declarar uma set/get DbSet para cada entidade do projeto
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Produto> Produto { get; set; }

        //REGRA 4) Sobrescrever (OVERRIDE) o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
