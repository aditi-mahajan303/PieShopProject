using PieShopProject.DataAccess.Data;
using PieShopProject.DataAccess.Repository.IRepository;
using PieShopProject.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopProject.DataAccess.Repository
{
    public class PieRepository : Repository<Pie>, IPieRepository
    {
        private readonly PieShopDBContext _db;

        public PieRepository(PieShopDBContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
