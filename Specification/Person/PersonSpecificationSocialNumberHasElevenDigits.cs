using Kadry.Db.Data;

namespace Specification.Person
{
    public class PersonSpecificationSocialNumberHasElevenDigits<T> : CompositeSpecification<T>
    {
        public override bool IsSatisfiedBy(T o)
        {
            if (!(o is PersonDb))
            {
                return false;
            }
            var person = o as PersonDb;
            return person.SocialNumber.Length == 11;
        }
    }
}
