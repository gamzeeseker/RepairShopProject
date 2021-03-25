using Microsoft.EntityFrameworkCore;
using RepairShopProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.DataAccess.Concrete.EntityFramework
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly RepairShopContext _dbContext;
        public DbSet<TEntity> Table { get; set; }

        #endregion

        #region Ctor

        public Repository(RepairShopContext repairShopContext)
        {
            this._dbContext = repairShopContext;
            this.Table = _dbContext.Set<TEntity>();
        }

        #endregion

        #region Methods

        public void Delete(TEntity entity)
        {
            Table.Remove(entity);
            _dbContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Table.Find(id);
        }

        public void Insert(TEntity entity)
        {
            Table.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Table.Attach(entity);
            _dbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
