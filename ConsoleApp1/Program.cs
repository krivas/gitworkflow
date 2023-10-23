// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");
Console.WriteLine("sup");
Console.WriteLine("sup2");
Console.WriteLine("sup3");

string currentDirectory = Directory.GetCurrentDirectory();

Console.WriteLine("Current Working Directory: " + currentDirectory);
//for (int i = 0; i < args.Length; i++)
//{
if (File.Exists("C:\\Users\\PC\\source\\gitworkflow\\criteria.json.txt"))
    {
        var file=File.ReadAllText("C:\\Users\\PC\\source\\gitworkflow\\criteria.json.txt");
        Console.WriteLine(file);
        var respone=JsonConvert.DeserializeObject<Criteria>(file);
        Console.WriteLine(respone.Length);
    foreach (var item in respone.Allow)
    {
        Console.WriteLine(item);
    }
    foreach (var item in respone.Forbidden)
    {
        Console.WriteLine(item);
    }


    }
    Console.WriteLine("hi");   
    //Console.WriteLine($"Parameter {i + 1}: {args[i]}");
//}

Console.WriteLine("sup3");
Console.WriteLine("sup3");
Console.WriteLine("sup3");
Console.WriteLine("sup3");

Console.WriteLine("sup3");
Console.WriteLine("sup3");
Console.WriteLine("sup3");
Console.WriteLine("sup3");


public class Criteria
{
    public int Length { get; set; }
    public List<char> Allow { get; set; }
    public List<char> Forbidden { get; set; }
}


















