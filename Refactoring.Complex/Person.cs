using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Complex
{
    public class Person
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }

        public Person()
        {
        }

        public Person(string name, DateTime birthDate)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (birthDate < DateTime.MinValue || birthDate > DateTime.MaxValue)
                throw new ArgumentNullException(nameof(birthDate));

            Name = name;
            BirthDate = birthDate;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public virtual bool IsYoungerThan(Person other) => BirthDate > other.BirthDate;

        public override string ToString() => Name;
    }
}
