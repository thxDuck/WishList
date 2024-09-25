using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WishList.Models;

namespace WishList.Data
{
    public class WishListContext : DbContext
    {
        public WishListContext (DbContextOptions<WishListContext> options)
            : base(options)
        {
        }

        public DbSet<WishList.Models.Wish> Wish { get; set; } = default!;
    }
}
