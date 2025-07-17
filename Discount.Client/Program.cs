using System.Net.Sockets;
using System.IO;

while (true)
{
    Console.WriteLine("****************************");
    Console.WriteLine("*   Discount Code Client   *");
    Console.WriteLine("****************************");
    Console.WriteLine("1. Generate Codes.");
    Console.WriteLine("2. Use Code.");
    Console.WriteLine("Q. Quit.");
    Console.Write("Choose: ");

    var choice = Console.ReadLine()?.ToLower();

    if (choice == "q")
        break;

    using var client = new TcpClient();
    await client.ConnectAsync("127.0.0.1", 5000);

    using var stream = client.GetStream();
    using var reader = new BinaryReader(stream);
    using var writer = new BinaryWriter(stream);

    if (choice == "1")
    {
        Console.Write("How many codes to generate? ");
        ushort count = ushort.Parse(Console.ReadLine()!);

        Console.Write("Code length? ");
        byte length = byte.Parse(Console.ReadLine()!);

        writer.Write((byte)1);       // operation: generate
        writer.Write(count);
        writer.Write(length);

        var success = reader.ReadBoolean();
        if (success)
        {
            Console.WriteLine("Generated Codes:");
            for (int i = 0; i < count; i++)
            {
                var code = reader.ReadString();
                Console.WriteLine($"[{i + 1}] {code}");
            }
        }
    }
    else if (choice == "2")
    {
        Console.Write("Enter code to use: ");
        var code = Console.ReadLine()!;

        writer.Write((byte)2);       // operation: use
        writer.Write(code);

        var result = reader.ReadByte();

        var message = result switch
        {
            0 => "Code not found.",
            1 => "Code used successfully!",
            2 => "Code already used.",
            _ => "Unknown response."
        };

        Console.WriteLine(message);
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }

    Console.WriteLine("\n\n");
  
}


