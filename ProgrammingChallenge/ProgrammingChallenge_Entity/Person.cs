using System.Collections.Generic;

namespace ProgrammingChallenge_Entity
{
    public class Person
    {
        public int Age { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public IList<Pet> Pets { get; set; }
    }
}