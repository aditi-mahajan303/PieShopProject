using PieShopProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopProject.DataAccess.Repository.IRepository
{
    public interface IPieRepository : IRepository<Pie>
    {
        void Save();
    }
}
