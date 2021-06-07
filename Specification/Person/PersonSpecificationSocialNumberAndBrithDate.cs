using Kadry.Db;
using Kadry.Db.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.Person
{
    public class PersonSpecificationSocialNumber : IPersonSpecification
    {
        private string weightsChar = "13791379131";
        private short[] weights = new short[11];
        private short[] values = new short[11];
        public bool IsSatisfiedBy(PersonDb person)
        {
            if (person.SocialNumber.Length != 11)
                return false;

            for (var i= 0;i<11;i++)
            {
                values[i] = Convert.ToInt16(person.SocialNumber[i].ToString());
                weights[i] = Convert.ToInt16(weightsChar[i].ToString());
            }


            return true;
        }
    }
}
