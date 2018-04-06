using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ProgrammingChallenge_Data;
using ProgrammingChallenge_Entity;
using StructureMap;

namespace ProgrammingChallenge_Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService()
            : this(ObjectFactory.GetInstance<IPersonRepository>())
        {
        }

        /// <summary>
        /// Initializing SimpleInjector Container
        /// </summary>
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
         
        public Dictionary<string, List<Pet>> GetPersonsList()
        {
            var petsList = JsonConvert.DeserializeObject<List<Person>>(_personRepository.GetPetsListData().Result);
            var data = petsList.AsQueryable();
            var query = data.Where(person => person.Pets != null).GroupBy(person => person.Gender).Select(grouping => new
            {
                Gender = grouping.Key,
                Pets = grouping.SelectMany(person => person.Pets)
                    .Where(pet => pet.Type.ToUpper().Equals("CAT", StringComparison.InvariantCultureIgnoreCase))
                    .OrderBy(pet => pet.Name)
                    .ToList(),
            });

            return query.ToDictionary(arg => arg.Gender, arg => arg.Pets);
        }
    }
}
