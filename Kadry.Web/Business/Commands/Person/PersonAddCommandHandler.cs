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
        public ICommand Execute(PersonAddCommand command)
        {
            try
            {
                if (
                    !new PersonSpecificationSocialNumberHasElevenDigits<PersonDb>()
                    .And(new PersonSpecificationSocialNumberAndBrithDateMatch<PersonDb>()).IsSatisfiedBy(command.Person)
                    )
                {
                    command.CommandError = string.Format("Pole pesel nie spełnia wymagań. ({0}).", command.Person.SocialNumber);
                    command.IsError = true;
                    return command;
                }
                var persons = new KadryRepository<PersonDb>(_context);
                var person = persons.Filter(x => x.SocialNumber == command.Person.SocialNumber).FirstOrDefault();
                if (person != null)
                {
                    command.CommandError = string.Format("W bazie istnieje już osoba z tym numerem PESEL ({0}).", command.Person.SocialNumber);
                    command.IsError = true;
                    return command;
                }
                if (command.Person.Id > 0)
                {
                    persons.Attache(person);
                }
                else
                {
                    persons.Insert(command.Person);
                }
                command.RowsAffected = 1;
                return command;
            }
            catch (InvalidOperationException iExp)
            {
                command.IsError = true;
                command.CommandError = string.Format("{0}; {1}", iExp.Message, iExp.InnerException != null ? iExp.InnerException.Message : "");
                return command;
            }
        }
    }
}
