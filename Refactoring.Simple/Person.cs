using System;

namespace Refactoring.Simple
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string name, DateTime birthDate)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (birthDate < DateTime.MinValue || birthDate > DateTime.MaxValue)
                throw new ArgumentNullException(nameof(birthDate));

            Name = name;
            BirthDate = birthDate;
        }

        public virtual bool IsYoungerThan(Person other) => BirthDate > other.BirthDate;
    }
}
