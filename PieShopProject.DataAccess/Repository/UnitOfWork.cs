using PieShopProject.DataAccess.Data;
using PieShopProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PieShopDBContext _db;
        public UnitOfWork(PieShopDBContext db)
        {
            _db = db;
            Pie = new PieRepository(_db);
            
        }

        public IPieRepository Pie { get; private set; }

        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
