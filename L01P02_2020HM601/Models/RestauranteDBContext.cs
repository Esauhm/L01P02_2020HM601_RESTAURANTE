using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace L01P02_2020HM601.Models
{
    public class RestauranteDBContext : DbContext
    {
        public RestauranteDBContext(DbContextOptions<RestauranteDBContext> options) : base(options)
        {
        }

        public DbSet<clientes> Clientes { get; set; }

        public DbSet<motoristas> Motoristas { get; set; }

        public DbSet<pedidos> Pedidos { get; set; }

        public DbSet<platos> Platos { get; set; }
    }
}
