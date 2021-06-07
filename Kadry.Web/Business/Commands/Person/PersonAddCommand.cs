using CQRS;
using Kadry.Db.Data;

namespace Kadry.Web.Business.Commands.Person
{
    public class PersonAddCommand : Command, ICommand
    {
        public PersonDb Person {get;set;}
    }
}
