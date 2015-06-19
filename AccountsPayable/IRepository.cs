using System.Collections.Generic;

namespace AccountsPayable
{
    public interface IRepository<TEntity, in TKey> where TEntity : class 
    {
        IApDataContext Context { get; set; }
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}