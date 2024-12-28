using MBusParserCS;
using System.Text.Json;
using Cli.Models;

Console.WriteLine("----------------------- T K   M - B U S   P A R S E R -----------------------");
Console.WriteLine();

while(true)
{
    Console.WriteLine("Enter M-Bus frame (hex):");
    String? frame = Console.ReadLine();

    Console.WriteLine("Enter decryption key (hex) - optional:");
    String? key = Console.ReadLine();

    IParser parser = new Parser();
    String resultJson = parser.Parse(frame, key);
    Result? result = JsonSerializer.Deserialize<Result>(resultJson);

    Console.WriteLine("----------------------- T K   M - B U S   P A R S E R -----------------------");

    if (result == null)
    {
        Console.WriteLine("Parser fatal error");
    }
    else
    {
        Console.WriteLine(result.ToString());
    }
}