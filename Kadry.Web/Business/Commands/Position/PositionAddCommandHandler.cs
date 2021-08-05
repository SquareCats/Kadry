using CQRS;
using Kadry.Db.Data;
using Kadry.Web.Data.Context;
using Kadry.Web.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kadry.Web.Business.Commands.Position
{
    public class PositionAddCommandHandler : ICommandHandler<PositionAddCommand>
    {
        private readonly KadryDbContext _context;

        public PositionAddCommandHandler(KadryDbContext context) 
        {
            this._context = context;
        }
        public ICommand Execute(PositionAddCommand command)
        {
            try
            {
                var positions = new KadryRepository<PositionDb>(_context);
                var position = positions.Filter(x => x.Person.Id == command.Position.Person.Id && x.ContractDate.Date == command.Position.ContractDate.Date).FirstOrDefault();
                if (position != null)
                {
                    command.CommandError = string.Format("W bazie istnieje już wpis o umowie dla osoby z numerem PESEL:{0} w dniu {1}.", command.Position.Person.Id, command.Position.ContractDate.ToShortDateString());
                    command.IsError = true;
                    return command;
                }
                positions.Insert(command.Position);
                command.RowsAffected = 1;
                return command;
            }
            catch(InvalidOperationException iExp)
            {
                command.IsError = true;
                command.CommandError = string.Format("{0}; {1}", iExp.Message, iExp.InnerException != null ? iExp.InnerException.Message : "");
                return command;
            }
        }
    }
}

