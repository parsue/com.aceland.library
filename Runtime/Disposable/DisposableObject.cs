using System;
using Newtonsoft.Json;

namespace AceLand.Library.Disposable
{
    public abstract class DisposableObject : IDisposable
    {
        [JsonIgnore]
        public bool Disposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected void Dispose(bool disposing)
        {
            if (Disposed) return;

            if (disposing)
            {
                DisposeManagedResources();
                DisposeUnmanagedResources();
            }

            Disposed = true;
        }

        protected virtual void DisposeManagedResources()
        {
            // noop
        }

        protected virtual void DisposeUnmanagedResources()
        {
            // noop
        }
    }
}