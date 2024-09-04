using System;
using AceLand.Library.Models;

namespace AceLand.Library.Promise
{
    public abstract class ProgressPromiseHandler<T> : PromiseHandler<T> 
        where T : ProgressPromiseHandler<T>
    {
        protected Action<ProgressData> InProgress { get; private set; } = null;

        protected ProgressData ProgressData;

        public virtual T Progress(Action<ProgressData> inProgress)
        {
            InProgress += inProgress;
            return (T)this;
        }
    }

    public abstract class ProgressPromiseHandler<T, TError> : PromiseHandler<T, TError> 
        where T : ProgressPromiseHandler<T, TError>
    {
        protected Action<ProgressData> InProgress { get; private set; } = null;

        protected ProgressData ProgressData;

        public virtual T Progress(Action<ProgressData> inProgress)
        {
            InProgress += inProgress;
            return (T)this;
        }
    }

    public abstract class ProgressPromiseHandler<T, TSuccess, TError> : PromiseHandler<T, TSuccess, TError> 
        where T : ProgressPromiseHandler<T, TSuccess, TError>
    {
        protected Action<ProgressData> InProgress { get; private set; } = null;

        protected ProgressData ProgressData;

        public virtual T Progress(Action<ProgressData> inProgress)
        {
            InProgress += inProgress;
            return (T)this;
        }
    }
}