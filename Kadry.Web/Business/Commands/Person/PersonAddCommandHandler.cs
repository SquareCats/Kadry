using System;
using CQRS;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kadry.Web.Data.Context;
using Kadry.Web.Data.Repository;
using Kadry.Db.Data;
using Specification.Person;

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
            if(
                !new PersonSpecificationSocialNumberHasElevenDigits<PersonDb>()
                .And(new PersonSpecificationSocialNumberAndBrithDateMatch<PersonDb>()).IsSatisfiedBy(command.Person)
                )
            {
                command.CommandError = string.Format("Pole pesel nie spełnia wymagań. ({0}).", command.Person.SocialNumber);
                command.IsError = true;
                return result;
            }
            var persons = new KadryRepository<PersonDb>(_context);
            var person = persons.Filter(x => x.SocialNumber == command.Person.SocialNumber).FirstOrDefault();
            if (person!=null)
            {
                command.CommandError = string.Format("W bazie istnieje już osoba z tym numerem PESEL ({0}).", command.Person.SocialNumber);
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
