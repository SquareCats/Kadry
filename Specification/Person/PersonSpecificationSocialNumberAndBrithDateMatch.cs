using Kadry.Db.Data;
using System;

namespace Specification.Person
{
    public class PersonSpecificationSocialNumberAndBrithDateMatch<T> : CompositeSpecification<T>
    {
        private string weightsChar = "13791379131";
        private short[] weights = new short[11];
        private short[] values = new short[11];
        public override bool IsSatisfiedBy(T o)
        {
            if (!(o is PersonDb))
            {
                return false;
            }
            var person = o as PersonDb;
            for (var i= 0;i<11;i++)
            {
                values[i] = Convert.ToInt16(person.SocialNumber[i].ToString());
                weights[i] = Convert.ToInt16(weightsChar[i].ToString());
            }

            var sum = 0;
            for (var i = 0; i < 10; i++)
            {
                sum+=values[i]* weights[i];
            }
            var moduloTen = sum % 10;
            var parity = 10 - moduloTen;
            if (parity == 10)
                parity = 0;
            if (values[10]== parity)
            {
                return true;
            }
            return false;
        }
    }
}
