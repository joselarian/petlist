using System.Threading.Tasks;

namespace ProgrammingChallenge_Data
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Get data from agl developer test service
        /// </summary>
        /// <returns></returns>
        Task<string> GetPetsListData();
    }
}