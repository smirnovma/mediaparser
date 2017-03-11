using MediaParser.Data.Context;
using MediaParser.Data.SqlRepository;
using MediaParser.Entities.Entities;
using MediaParser.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaParser.Data
{
    public class UnitOfWork : IDisposable
    {
        private SqlDbContext db = new SqlDbContext();
        private IRepository<InputLinkHistoryEntity> inputLinkHistoryRepository;

        public IRepository<InputLinkHistoryEntity> InputLinkHistoryRepository
        {
            get
            {
                return inputLinkHistoryRepository ?? (inputLinkHistoryRepository = new InputLinkHistoryRepository(db));
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
