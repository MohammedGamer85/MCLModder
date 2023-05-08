using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MCLModder;
using System.Dynamic;

Console.WriteLine("I wish this will work");
Console.WriteLine("=====================");

Vars Vars = new Vars();
Extra Extra = new Extra();

getModpack();

void getModpack()
{
    string AD = Vars.AppDirectory;

    //Get the location of imported modpack;
    Console.WriteLine("Please Enter the location of your modpack folder");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("$ ");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Blue;
    string MPL = Console.ReadLine();
    Console.ResetColor();
    Console.WriteLine(MPL + " -- " + Vars.DocFileDirecotry + "mods\\");

    try
    {
        Extra.CheckAndRequestReadPermission();
        Extra.CheckAndRequestWritePermission();
        File.Copy(MPL, Vars.DocFileDirecotry + "mods\\");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Access Dinied");
    }

    Console.WriteLine("click to close");
    Console.ReadLine();
}

