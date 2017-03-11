using MediaParser.Data.Context;
using MediaParser.Entities.Entities;
using MediaParser.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaParser.Data.SqlRepository
{
    class InputLinkHistoryRepository : IRepository<InputLinkHistoryEntity>
    {
        private SqlDbContext db;

        public InputLinkHistoryRepository()
        {
            db = new SqlDbContext();
        }
        public InputLinkHistoryRepository(SqlDbContext sqlDbContext)
        {
            db = sqlDbContext;
        }
        public void Create(IEnumerable<InputLinkHistoryEntity> items)
        {
            foreach (var item in items)
            {
                db.InputLinkHistory.Add(item);
            }
        }

        public void Create(InputLinkHistoryEntity item)
        {
            db.InputLinkHistory.Add(item);
        }

        public void Delete(int id)
        {
            InputLinkHistoryEntity errorEntity = db.InputLinkHistory.Find(id);
            if (errorEntity != null)
            {
                db.InputLinkHistory.Remove(errorEntity);
            }
        }

        public IQueryable<InputLinkHistoryEntity> GetEntities()
        {
            return db.InputLinkHistory;
        }

        public InputLinkHistoryEntity GetEntity(int id)
        {
            return db.InputLinkHistory.Find(id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(InputLinkHistoryEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
