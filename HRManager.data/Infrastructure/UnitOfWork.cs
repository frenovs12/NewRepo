using HRManager.data;
using System;
using System.Data.Entity.Validation;

namespace HRManager.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private HRManagerContext dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;

        }



        public void Commit()
        {

            dataContext.SaveChanges();

        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
        public IRepositoryBase<T> getRepository<T>() where T : class
        {
            IRepositoryBase<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }

    }
}
