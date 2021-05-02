using System;
using Microsoft.Extensions.DependencyInjection;
namespace CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider service;

        public CommandDispatcher(IServiceProvider service)
        {
            this.service = service;
            ErrorMessage = "";
            CommandRetunedError = false;
        }

        public string ErrorMessage { get; set; }
        public bool CommandRetunedError { get; set; }

        public int Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            var handler = service.GetService<ICommandHandler<TCommand>>();
            if (handler==null)
            {
                throw new CommandHandlerNotFoundxception(typeof(TCommand));
            }
            command.RowsAffected = handler.Execute(command);
            return command.RowsAffected;
        }

        public class CommandHandlerNotFoundxception : Exception
        {
            public CommandHandlerNotFoundxception(Type type)
            {
                throw new ArgumentNullException(type.FullName);
            }
        }
    }
}
