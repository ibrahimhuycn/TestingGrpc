using Grpc.Core;
using GrpcClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class AddressService:Address.AddressBase
    {
        private readonly ILogger<AddressService> _logger;
        public AddressService(ILogger<AddressService> logger)
        {
            _logger = logger;
        }

        public override Task<SaveStatus> SaveAddress(AddressBook request, ServerCallContext context)
        {
            foreach (var item in request.People)
            {
                Console.WriteLine($"{item.Name} {item.Email}");
            }

            return Task.Run(() =>
            {
                return new SaveStatus() { IsSaved = true };
            });

        }
    }
}
