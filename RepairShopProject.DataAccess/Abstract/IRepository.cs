using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.DataAccess.Abstract
{
    public partial interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Table { get; }

        TEntity GetById(int id);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
