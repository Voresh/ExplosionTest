using System;

namespace Services.Base
{
    public interface IService : IDisposable
    {
        void Initialize();
    }
}