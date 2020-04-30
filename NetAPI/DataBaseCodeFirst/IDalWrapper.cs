using System;
using VieJSLearning.Dal.Entities;
using VieJSLearning.Dal.Repositories;

namespace VieJSLearning.Dal
{
    public interface IDalWrapper : IDisposable
    {
        void Save();
        VieJSLearningContext GetContext { get; }
        IGenericRepository<UserEntity> UserRepository { get; }
        void Migration();
    }
}