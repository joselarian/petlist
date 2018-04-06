using System;
using System.Collections.Generic;
using ProgrammingChallenge_Entity;
using ProgrammingChallenge_Service;
using StructureMap;
namespace ProgrammingChallenge
{
    class Program
    {
        private static readonly IPersonService PersonService;
         
        static Program()
        {
            //Configure StructureMap
            ObjectFactory.Initialize(x => x.AddRegistry(new ComponentRegistry()));
            PersonService = ObjectFactory.GetInstance<IPersonService>();
        }

        static void Main()
        { 
            var persons = PersonService.GetPersonsList();
            OutputData(persons);
            Console.WriteLine();
            Console.WriteLine("Press esc key to exit");
            Console.ReadKey();
        }

        private static void OutputData(Dictionary<string, List<Pet>> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}");
                foreach (var pet in item.Value)
                {
                    Console.WriteLine($"\t{pet.Name}");
                }
            }
        }
    }
}
