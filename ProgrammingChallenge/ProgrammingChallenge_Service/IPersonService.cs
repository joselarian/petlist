using System.Collections.Generic;
using ProgrammingChallenge_Entity;

namespace ProgrammingChallenge_Service
{
    public interface IPersonService
    {
        Dictionary<string, List<Pet>> GetPersonsList();
    }
}