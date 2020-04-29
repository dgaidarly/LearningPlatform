using System;
using VieJSLearning.Dal.Entities;
using VieJSLearning.Dal.Repositories;

namespace VieJSLearning.Dal
{
    public class DalWrapper: IDalWrapper
    {
        private readonly VieJSLearningContext context;
        private IGenericRepository<UserEntity> userRepository;

        public DalWrapper()
        {
            context=new VieJSLearningContext();
        }
        public void Save()
        {
            context.SaveChanges();
        }

        #region IDisposible
        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }

    public interface IDalWrapper : IDisposable
    {
        void Save();
    }
}