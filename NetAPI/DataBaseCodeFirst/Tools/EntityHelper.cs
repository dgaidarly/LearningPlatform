using System;
using VieJSLearning.Dal.Entities;

namespace VieJSLearning.Dal.Tools
{
    public static class EntityHelper
    {
        public static void SetId(this UserEntity entity)
        {
            var id = Guid.NewGuid().ToString("N").ToUpperInvariant();
            entity.Id = id;
        }
    }
}