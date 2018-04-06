using System.Net.Http;
using System.Threading.Tasks; 

namespace ProgrammingChallenge_Data
{
    public class PersonRepository : IPersonRepository
    {
        /// <summary>
        /// Get data from agl developer test service
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPetsListData()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(@"http://agl-developer-test.azurewebsites.net/people.json");
            response.EnsureSuccessStatusCode();
            return  await response.Content.ReadAsStringAsync();
        }
    }
}
