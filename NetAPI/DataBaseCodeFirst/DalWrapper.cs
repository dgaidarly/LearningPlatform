using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using VieJSLearning.Dal.Entities;
using VieJSLearning.Dal.Repositories;

namespace VieJSLearning.Dal
{
    public class DalWrapper: IDalWrapper
    {
        private readonly VieJSLearningContext context;
        private IGenericRepository<UserEntity> userRepository;

        public VieJSLearningContext GetContext => context;

        public DalWrapper()
        {
            context=new VieJSLearningContext();
        }

        public IGenericRepository<UserEntity> UserRepository => userRepository ?? new GenericRepository<UserEntity>(context);

        public void Migration()
        {
            var mgr = context.GetInfrastructure().GetService<IMigrator>();
            mgr.Migrate();
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
}