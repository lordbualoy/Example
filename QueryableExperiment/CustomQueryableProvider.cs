using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QueryableExperiment
{
    public class CustomQueryableProvider<T> : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            return new CustomQueryable<T>();
        }

        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            return (IQueryable<T>)CreateQuery(expression);
        }

        public object? Execute(Expression expression)
        {
            return new CustomQueryableExecutor().Execute(expression);
        }

        public T Execute<T>(Expression expression)
        {
            return (T)Execute(expression);
        }
    }
}
