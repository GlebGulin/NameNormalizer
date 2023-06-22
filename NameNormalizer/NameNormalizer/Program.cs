using NameNormalizer.Services;
using System;
using System.Threading.Tasks;

namespace NameNormalizer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool again = true;
            while (again)
            {
                Console.WriteLine("Please, enter the fullname:");
                string fullName = Console.ReadLine();
                INameService service = new NameService();
                string result = await service.NormalizeName(fullName);
                Console.WriteLine(result);
                Console.WriteLine("Press any key to continue. To exit, press the Q key");
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Q)
                {
                    again = false;
                    break;
                }
            }
        }
    }
}
