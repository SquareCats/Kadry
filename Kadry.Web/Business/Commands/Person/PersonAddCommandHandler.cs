using System;
using CQRS;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kadry.Web.Data.Context;

namespace Kadry.Web.Business.Commands.Person
{
    public class PersonAddCommandHandler : ICommandHandler<PersonAddCommand>
    {
        public PersonAddCommandHandler(KadryDbContext context)
        {

        }
        public int Execute(PersonAddCommand command)
        {
            return 0;
        }
    }
}
