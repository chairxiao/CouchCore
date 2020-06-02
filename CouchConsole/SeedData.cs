using System;
using CouchConsole.Models;
using MyCouch;
using System.Threading.Tasks;

namespace CouchConsole
{
    public static class SeedData
    {
        public static async void Init()
        {
            // example datas
            Person person1 = new Person("1", "person1");
            Person person2 = new Person { Id = "2", Name = "person2" };

            using (var client = new MyCouchClient("http://admin:123qwe@127.0.0.1:5984/", "mydb"))
            {
                var flag1 = await client.Documents.GetAsync(person1.Id);
                var flag2 = await client.Documents.GetAsync(person2.Id);

                if (!flag1.IsSuccess)
                    await client.Entities.PostAsync(person1);
                if (!flag2.IsSuccess)
                    await client.Entities.PostAsync(person2);
            }
        }
    }
}
