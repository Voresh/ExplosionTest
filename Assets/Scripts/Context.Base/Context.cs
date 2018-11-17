using System;
using System.Collections.Generic;
using Services.Base;

namespace Context.Base
{
    public abstract class Context : IDisposable
    {
        protected readonly List<IService> Services = new List<IService>();

        public abstract void Init();

        protected void AddService(IService service)
        {
            Services.Add(service);
        }

        protected void InitializeServices()
        {
            Services.ForEach(_ => { _.Initialize(); });
        }

        void IDisposable.Dispose()
        {
            Services.ForEach(_ => { _?.Dispose(); });
            Services.Clear();
        }
    }
}