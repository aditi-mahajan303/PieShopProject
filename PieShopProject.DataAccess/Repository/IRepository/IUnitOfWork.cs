using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieShopProject.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IPieRepository Pie { get; }
        
        void Save();
    }
}
