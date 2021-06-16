using Kadry.Db.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specification;
using Specification.Person;
using System;

namespace Kadry.Tests
{
    [TestClass]
    public class PersonSpecificationsTests
    {
        public PersonDb personGoodToCheck;
        public PersonDb personInvalidToCheck;
        [TestInitialize]
        public void PersonSpecificationsTestsInit()
        {
             personGoodToCheck = new PersonDb
            {
                Id = 0,
                SocialNumber = "11111111116",
                CreatedBy = new Db.AppUser(),
                CreatedOn = DateTime.Now,
                ObjectGuid = Guid.NewGuid(),
                DateOfBirth = new DateTime(1911, 11, 9)
            };
            personInvalidToCheck = new PersonDb
            {
                Id = 0,
                SocialNumber = "11121111115",
                CreatedBy = new Db.AppUser(),
                CreatedOn = DateTime.Now,
                ObjectGuid = Guid.NewGuid(),
                DateOfBirth = new DateTime(1911, 11, 9)
            };
        }
        [TestMethod]
        public void CheckIfPersonSpecificationCorrectSocialNumberAndBrithDateMatchWorks()
        {
            var socialNumberAndDataBirthSpec = new PersonSpecificationSocialNumberAndBrithDateMatch<PersonDb>();
            var isSatisfied = socialNumberAndDataBirthSpec.IsSatisfiedBy(personGoodToCheck);
            Assert.AreEqual(true, isSatisfied);
        }
        [TestMethod]
        public void CheckIfPersonSpecificationInvalidSocialNumberAndBrithDateMatchWorks()
        {
            var socialNumberAndDataBirthSpec = new PersonSpecificationSocialNumberAndBrithDateMatch<PersonDb>();
            var isSatisfied = socialNumberAndDataBirthSpec.IsSatisfiedBy(personInvalidToCheck);
            Assert.AreEqual(false, isSatisfied);
        }
        [TestMethod]
        public void CheckIfAndSpecificationsGoodAllWorks()
        {
            ISpecification<PersonDb> socialNumberAndDataBirthSpec = new PersonSpecificationSocialNumberAndBrithDateMatch<PersonDb>();
            var socialNumberLengthEleven = new ExpressionSpecification<PersonDb>(x => x.SocialNumber.Length == 11);
            var isSatisfied =   socialNumberAndDataBirthSpec
                                .And(socialNumberLengthEleven)
                                .IsSatisfiedBy(personInvalidToCheck);
            Assert.AreEqual(false, isSatisfied);
        }

        [TestMethod]
        public void CheckIfPersonExpressionSpecificationWorks()
        {
            var socialNumberLengthEleven = new ExpressionSpecification<PersonDb>(x=>x.SocialNumber.Length==11);
            var isSatisfied = socialNumberLengthEleven.IsSatisfiedBy(personGoodToCheck);
            Assert.AreEqual(true, isSatisfied);
        }
    }
}
