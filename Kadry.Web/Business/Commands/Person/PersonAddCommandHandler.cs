using System;
using CQRS;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kadry.Web.Data.Context;
using Kadry.Web.Data.Repository;
using Kadry.Db.Data;

namespace Kadry.Web.Business.Commands.Person
{
    public class PersonAddCommandHandler : ICommandHandler<PersonAddCommand>
    {
        private readonly KadryDbContext _context;

        public PersonAddCommandHandler(KadryDbContext context)
        {
            this._context = context;
        }
        public int Execute(PersonAddCommand command)
        {
            var result = -1;
            var persons = new KadryRepository<PersonDb>(_context);
            var person = persons.Filter(x => x.SocialNumber == command.Person.SocialNumber).FirstOrDefault();
            if (person!=null)
            {
                command.CommandError = string.Format("A person with this social number already exists in the database ({0}).", command.Person.SocialNumber);
                command.IsError = true;
                return result;
            }
            persons.Insert(command.Person);
            command.RowsAffected = 1;
            result = 0;
            return result;
        }
    }
}
