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

        public ICommand Execute<TCommand>(TCommand command) where TCommand : ICommand
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
            try
            {
                var result = handler.Execute(command);
            }
            catch(ArgumentException argExp)
            {
                command.CommandError = string.Format("{0} {1}"
                    , argExp.Message
                    , argExp.InnerException != null ? argExp.InnerException.Message : "");
                command.IsError = true;
            }
            catch (Exception exp)
            {
                command.CommandError = string.Format("{0} {1}"
                    , exp.Message
                    , exp.InnerException != null ? exp.InnerException.Message : "");
                command.IsError = true;
            }
            return command;
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
