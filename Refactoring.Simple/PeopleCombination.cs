using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Simple
{
    public class PeopleCombination
    {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan BirthDateDiff { get; set; }

        public PeopleCombination()
        {
        }

        public PeopleCombination(Person firstPerson, Person secondPerson, TimeSpan birthDateDiff)
        {
            if (firstPerson is null)
                throw new ArgumentNullException(nameof(firstPerson));

            if (secondPerson is null)
                throw new ArgumentNullException(nameof(secondPerson));

            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
            BirthDateDiff = birthDateDiff;
        }

        public void Set(Person firstPerson, Person secondPerson)
        {
            if (firstPerson is null)
                throw new ArgumentNullException(nameof(firstPerson));

            if (secondPerson is null)
                throw new ArgumentNullException(nameof(secondPerson));

            FirstPerson = firstPerson;
            SecondPerson = secondPerson;

            BirthDateDiff = SecondPerson.BirthDate - FirstPerson.BirthDate;
        }

        public override string ToString() =>
            $"Seniority diff between {FirstPerson} and {SecondPerson}: {BirthDateDiff.TotalDays} days.";
    }
}
