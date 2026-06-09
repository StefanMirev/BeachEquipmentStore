namespace BeachEquipmentStore.Services.Infrastructure
{
    using Microsoft.EntityFrameworkCore.Query;
    using System.Linq.Expressions;

    internal class DbAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        internal DbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
            => new DbAsyncEnumerable<TEntity>(expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            => new DbAsyncEnumerable<TElement>(expression);

        public object? Execute(Expression expression)
            => _inner.Execute(expression);

        public TResult Execute<TResult>(Expression expression)
            => _inner.Execute<TResult>(expression);

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken = default)
        {
            var resultType = typeof(TResult).GetGenericArguments()[0];
            var result = typeof(IQueryProvider)
                .GetMethod(nameof(IQueryProvider.Execute), 1, [typeof(Expression)])!
                .MakeGenericMethod(resultType)
                .Invoke(this, [expression]);

            return (TResult)typeof(Task)
                .GetMethod(nameof(Task.FromResult))!
                .MakeGenericMethod(resultType)
                .Invoke(null, [result])!;
        }
    }

    internal class DbAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        internal DbAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable) { }
        internal DbAsyncEnumerable(Expression expression) : base(expression) { }

        IQueryProvider IQueryable.Provider => new DbAsyncQueryProvider<T>(this);

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
            => new DbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
    }

    internal class DbAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        internal DbAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public T Current => _inner.Current;

        public ValueTask<bool> MoveNextAsync() => ValueTask.FromResult(_inner.MoveNext());

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return ValueTask.CompletedTask;
        }
    }

    internal static class QueryableExtensions
    {
        internal static IQueryable<T> AsAsyncQueryable<T>(this IQueryable<T> source)
        {
            if (source.Provider is IAsyncQueryProvider)
                return source;
            return new DbAsyncEnumerable<T>(source);
        }
    }
}
