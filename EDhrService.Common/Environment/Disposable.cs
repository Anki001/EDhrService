using System;

namespace EDhrService.Common.Environment
{
    public class Disposable : IDisposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                OnDispose();

            _disposed = true;
        }

        protected virtual void OnDispose() { }
    }
}
