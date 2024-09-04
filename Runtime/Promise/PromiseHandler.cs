using System;

namespace AceLand.Library.Promise
{
    public abstract class PromiseHandler<T> : IDisposable 
        where T : PromiseHandler<T>
    {
        protected internal Action OnSuccess { get; private set; } = null;
        protected internal Action OnError { get; private set; } = null;
        protected internal Action OnFinal { get; private set; } = null;

        public virtual T Then(Action onSuccess)
        {
            OnSuccess += onSuccess;
            return (T)this;
        }
        public virtual T Catch(Action onError)
        {
            OnError += onError;
            return (T)this;
        }
        public virtual T Final(Action onFinal)
        {
            OnFinal += onFinal;
            return (T)this;
        }

        public virtual void Dispose()
        {
            OnSuccess = null;
            OnError = null;
            OnFinal = null;
        }
    }

    public abstract class PromiseHandler<T, TError> : IDisposable 
        where T : PromiseHandler<T, TError>
    {
        protected internal Action OnSuccess { get; private set; } = null;
        protected internal Action<TError> OnError { get; private set; } = null;
        protected internal Action OnFinal { get; private set; } = null;

        public virtual T Then(Action onSuccess)
        {
            OnSuccess += onSuccess;
            return (T)this;
        }
        public virtual T Catch(Action<TError> onError)
        {
            OnError += onError;
            return (T)this;
        }
        public virtual T Final(Action onFinal)
        {
            OnFinal += onFinal;
            return (T)this;
        }

        public virtual void Dispose()
        {
            OnSuccess = null;
            OnError = null;
            OnFinal = null;
        }
    }

    public abstract class PromiseHandler<T, TSuccess, TError> : IDisposable 
        where T : PromiseHandler<T, TSuccess, TError>
    {
        protected internal Action<TSuccess> OnSuccess { get; private set; } = null;
        protected internal Action<TError> OnError { get; private set; } = null;
        protected internal Action OnFinal { get; private set; } = null;

        public virtual T Then(Action<TSuccess> onSuccess)
        {
            OnSuccess += onSuccess;
            return (T)this;
        }
        public virtual T Catch(Action<TError> onError)
        {
            OnError += onError;
            return (T)this;
        }
        public virtual T Final(Action onFinal)
        {
            OnFinal += onFinal;
            return (T)this;
        }

        public virtual void Dispose()
        {
            OnSuccess = null;
            OnError = null;
            OnFinal = null;
        }
    }
}