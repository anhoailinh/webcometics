using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webQuanao2.Models;

namespace webQuanao2.Data
{
    public class webQuanao2Context : DbContext
    {
        public webQuanao2Context (DbContextOptions<webQuanao2Context> options)
            : base(options)
        {
        }

        public DbSet<webQuanao2.Models.User> User { get; set; } = default!;

        public DbSet<webQuanao2.Models.Products>? Products { get; set; }

        public DbSet<webQuanao2.Models.Category>? Category { get; set; }

        public DbSet<webQuanao2.Models.Color>? Color { get; set; }

        public DbSet<webQuanao2.Models.Size>? Size { get; set; }

        public DbSet<webQuanao2.Models.Order>? Order { get; set; }

        public DbSet<webQuanao2.Models.OrderDetail>? OrderDetail { get; set; }

	




	}
}
