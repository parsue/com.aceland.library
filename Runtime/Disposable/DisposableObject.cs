using System;

namespace AceLand.Library.Disposable
{
    public abstract class DisposableObject : IDisposable
    {
        public bool Disposed { get; private set; }

        public void Dispose()
        {
            BeforeDispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }

            if (disposing)
            {
                DisposeUnmanagedState();
            }

            DisposeUnmanagedResources();

            Disposed = true;
        }

        protected virtual void BeforeDispose()
        {
            // noop
        }

        protected virtual void DisposeUnmanagedState()
        {
            // noop
        }

        protected virtual void DisposeUnmanagedResources()
        {
            // noop
        }
    }
}