using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;




namespace PIDEV.ServicePattern
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Private Fields
        // private readonly IRepositoryBaseAsync<TEntity> _repository;
        IUnitOfWork utwk;
        #endregion Private Fields



        public virtual void Add(TEntity entity)
        {
            ////_repository.Add(entity);
            utwk.GetRepositoryBase<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            //_repository.Update(entity);
            utwk.GetRepositoryBase<TEntity>().Update(entity);
        }

      

        public virtual TEntity GetById(int id)
        {
            //  return _repository.GetById(id);
            return utwk.GetRepositoryBase<TEntity>().GetById(id);
        }

        public virtual TEntity GetById(string id)
        {
            //return _repository.GetById(id);
            return utwk.GetRepositoryBase<TEntity>().GetById(id);
        }





        public void Commit()
        {
            try
            {
                utwk.commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public void Dispose()
        {
            utwk.Dispose();
        }
    }
}
