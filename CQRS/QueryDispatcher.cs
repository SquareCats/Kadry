using System;
using Microsoft.Extensions.DependencyInjection;
namespace CQRS
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider service;

        public QueryDispatcher(IServiceProvider service)
        {
            this.service = service;
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            if (query==null)
            {
                throw new ArgumentNullException("query");
            }
            var handler = service.GetService<IQueryHandler<TQuery, TResult>>();
            if (handler==null)
            {
                throw new QueryHandlerNotFoundxception(typeof(TQuery));
            }
            return handler.Execute(query);
        }
    }

    public class QueryHandlerNotFoundxception : Exception
    {
        public QueryHandlerNotFoundxception(Type type)
        {
            throw new ArgumentNullException(type.FullName);
        }
    }
}
