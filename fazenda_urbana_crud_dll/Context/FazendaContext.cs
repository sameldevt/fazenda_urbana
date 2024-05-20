using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fazenda_urbana_crud_dll.Models.Entities;

namespace fazenda_urbana_crud_dll.Context
{
    public class FazendaContext : DbContext
    {
        public FazendaContext(DbContextOptions<FazendaContext> options) : base(options)
        {

        }

        public DbSet<Cliente> clientes {get; set;}
        public DbSet<DetalheVenda> detalheVendas {get; set;}
        public DbSet<Fornecedor> fornecedores {get; set;}
        public DbSet<Funcionario> funcionarios {get; set;}
        public DbSet<Inventario> inventarios {get; set;}
        public DbSet<Pagamento> pagamentos {get; set;}
        public DbSet<Producao> producoes {get; set;}
        public DbSet<Produto> produtos {get; set;}
        public DbSet<Relatorio> relatorios {get; set;}
        public DbSet<Transporte> transportes {get; set;}
        public DbSet<Venda> vendas {get; set;}
    }
}