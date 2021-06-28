using CQRS;
using Kadry.Db.Data;

namespace Kadry.Web.Business.Commands.Position
{
    public class PositionAddCommand : Command, ICommand
    {
        public PositionDb Position { get; set; }
    }
}
