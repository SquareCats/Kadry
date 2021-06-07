using Kadry.Db.Data;

namespace Specification
{
    public interface IPersonSpecification
    {
        bool IsSatisfiedBy(PersonDb entity);
    }
}
