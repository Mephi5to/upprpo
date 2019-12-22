using System.Threading;
using System.Threading.Tasks;
using Client;

namespace FilesTool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var birdsApiClient = new BirdsApiClient();
            var loader = new Loader(birdsApiClient);

            loader.UploadFilesToServer("D:\\NSU\\УППРПО\\Sounds", CancellationToken.None);

        }
    }
}