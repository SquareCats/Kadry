
namespace CQRS
{
    public interface IQuery<TResult>
    {
        bool IsError { get; set; }
        string QueryError { get; set; }
        long OperationId { get; set; }
        string Host { get; set; }
        int RowsAffected { get; set; }
    }
    public class Query 
    {
        public bool IsError { get; set; }
        public string QueryError { get; set; }
        public long OperationId { get; set; }
        public string Host { get; set; }
        public int RowsAffected { get; set; }
        public Query()
        {
            IsError = false;
            QueryError = string.Empty;
            OperationId = 0;
            Host = string.Empty;
        }
    }

    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }

    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}
