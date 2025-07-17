using Discount.Application.Handler;
using Discount.Application.Interfaces;
using Discount.Domain.Factories;
using Discount.Domain.Interfaces;
using Discount.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Net.Sockets;

var services = new ServiceCollection();

// Dependency Injection Setup
services.AddSingleton<IDiscountCodeFactory, DiscountCodeFactory>();
services.AddSingleton<IDiscountCodeRepository, DiscountCodeRepository>();
services.AddSingleton<IGenerateCodesHandler, GenerateCodesHandler>();
services.AddSingleton<IUseCodeHandler, UseCodeHandler>();
services.AddLogging(config => config.AddConsole());

var provider = services.BuildServiceProvider();

// Load previously generated codes
var repo = provider.GetRequiredService<IDiscountCodeRepository>();
await repo.LoadAsync();

// TCP Server
var listener = new TcpListener(IPAddress.Loopback, 5000);
listener.Start();
Console.WriteLine("TCP Server started on port 5000...");

while (true)
{
    var client = await listener.AcceptTcpClientAsync();
    _ = Task.Run(() => HandleClientAsync(client, provider));
}

async Task HandleClientAsync(TcpClient client, IServiceProvider sp)
{
    using var stream = client.GetStream();
    using var reader = new BinaryReader(stream);
    using var writer = new BinaryWriter(stream);

    var op = reader.ReadByte(); // 1 = generate, 2 = use

    switch (op)
    {
        case 1:
            var count = reader.ReadUInt16();
            var length = reader.ReadByte();
            var codes = sp.GetRequiredService<IGenerateCodesHandler>().Handle(count, length);
            writer.Write(true); // success flag
            foreach (var code in codes)
                writer.Write(code);
            break;

        case 2:
            var inputCode = reader.ReadString();
            var result = sp.GetRequiredService<IUseCodeHandler>().Handle(inputCode);
            writer.Write(result);
            break;
    }
}
