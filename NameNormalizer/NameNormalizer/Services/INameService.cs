using System.Threading.Tasks;

namespace NameNormalizer.Services
{
    public interface INameService
    {
        Task<string> NormalizeName(string fullName); 
    }
}
