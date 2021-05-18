using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado_Do_zé.Models;
using System.Data;

namespace Mercado_Do_zé.Data
{
    public class Context : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }        
        
        
        private const string ConnectionString = @"Data Source=DESKTOP-ARTKF28\SQLEXPRESS;Initial Catalog=Desenvolvimento;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: ConnectionString);
        }
    }
}
