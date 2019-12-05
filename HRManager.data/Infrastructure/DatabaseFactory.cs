using HRManager.data;

namespace HRManager.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
#pragma warning disable IDE0044 // Add readonly modifier
        private HRManagerContext dataContext;
#pragma warning restore IDE0044 // Add readonly modifier
        public HRManagerContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new HRManagerContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
