using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIDEV.Data.Data.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        void commit();
        IRepositoryBase<T> GetRepositoryBase<T>() where T : class;





    }
}
