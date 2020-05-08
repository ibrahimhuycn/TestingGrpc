using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var input = new HelloRequest() { Name = "Hussain" };
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(input);

            Console.WriteLine(reply.Message);

            var reply2 = await Save();
            Console.WriteLine(reply2.IsSaved.ToString());
            Console.ReadLine();
        }

        private static async Task<SaveStatus> Save()
        {
            var input = new AddressBook();
            input.People.Add(new Person() { Name = "HUssain", Email = "adhjsa@asdgas.com"});
            input.People.Add(new Person() { Name = "Ibrahim", Email = "ibrahim@asdgas.com"});

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Address.AddressClient(channel);

            return await client.SaveAddressAsync(input);
        }
    }
}
