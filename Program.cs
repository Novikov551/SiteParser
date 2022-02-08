using SiteParser.Core; 
using SiteParser.Core.Habr;

var parser = new HabrParser();
var settings = new HabrSettings(); 

ParserWorker<string[]> worker = new(parser, settings); 
worker.OnUpdatedData += WriteDataToConsole;

void WriteDataToConsole(object arg1, string[] arg2)
{
    foreach (string arg in arg2)
    {
        Console.WriteLine(arg);
    }
}

worker.Start();

Console.Read();