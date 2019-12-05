
using HRManager.data;
using System;

namespace HRManager.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        HRManagerContext DataContext { get; }
    }

}
