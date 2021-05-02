namespace CQRS
{
    public class Command : ICommand
    {
        public bool IsError { get; set; }
        public string CommandError { get; set; }
        public long OperationId { get; set; }
        public string Host { get; set; }
        public int RowsAffected { get; set; }
        public Command()
        {
            IsError = false;
            CommandError = string.Empty;
            OperationId = 0;
            Host = string.Empty;
        }

    }
    public interface ICommand
    {
        bool IsError { get; set; }
        string CommandError { get; set; }
        long OperationId { get; set; }
        string Host { get; set; }
        int RowsAffected { get; set; }
    }

    public interface ICommandHandler<in TCommand> where TCommand:ICommand
    {
        int Execute(TCommand command);
    }
    public interface ICommandDispatcher
    {
        string ErrorMessage { get; set; }
        public bool CommandRetunedError { get; set; }
        public int Execute<TCommand>(TCommand comand) where TCommand : ICommand;
    }
}
