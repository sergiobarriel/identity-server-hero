using System.Threading.Tasks;

namespace Superheros.Console
{
    public class Program
    {
        public static void Main(string[] args) => MainAsync(args)
            .GetAwaiter()
            .GetResult();

        private static async Task MainAsync(string[] args) =>  await Display.ShowMenu();
    }
}
