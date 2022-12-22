using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PieShopProject.Models.Models;

namespace PieShopProject.DataAccess.Data
{
    public class PieShopDBContext:DbContext
    {
        public PieShopDBContext(DbContextOptions<PieShopDBContext> options) : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }

    }
}
