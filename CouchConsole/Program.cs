using System;
using System.Threading;
using System.Threading.Tasks;
using MyCouch;
using MyCouch.Requests;

namespace CouchConsole
{
    class Program
    {
        static async Task MainAsync()
        {
            var cnInfo = new DbConnectionInfo("http://admin:123qwe@127.0.0.1:5984/", "mydb")
            {
                Timeout = TimeSpan.FromMilliseconds(System.Threading.Timeout.Infinite)
            };
            using (var client = new MyCouchClient(cnInfo))
            {
                var getChangesRequest = new GetChangesRequest
                {
                    Feed = ChangesFeed.Continuous,
                    Since = "now", //Optional: FROM WHAT SEQUENCE DO WE WANT TO START CONSUMING
                    // Heartbeat = 3000, //Optional: LET COUCHDB SEND A I AM ALIVE BLANK ROW EACH ms
                    Filter = "person/filter_person"
                };

                var cancellation = new CancellationTokenSource();
                await client.Changes.GetAsync(
                    getChangesRequest,
                    data => ChangeDo(data),
                    cancellation.Token);

                cancellation.Cancel();
            }

        }
        private static void ChangeDo(Object x)
        {
            Console.WriteLine(x);
        }
        static void Main(string[] args)
        {
            // add example datas
            SeedData.Init();
            // capture couchdb changes 
            MainAsync().Wait();

            Console.WriteLine("Hello World!");
        }
    }
}
