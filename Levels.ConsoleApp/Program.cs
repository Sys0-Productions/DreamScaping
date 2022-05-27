// See https://aka.ms/new-console-template for more information

using MyNamespace;
using UnityEngine;

class Program
{
    static void Main(string[] args)
    {
        new ReportPool();
        
        StorageDrawFacade.Draw((2, 2));
        
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        
        StorageDrawFacade.Draw((2, 3));

        Console.WriteLine("\n");
        Console.WriteLine("\n");
        
        StorageDrawFacade.Draw((2, 5));

        Console.WriteLine("\n");
        Console.WriteLine("\n");
        
        StorageDrawFacade.Draw((20, 6));

        Console.WriteLine("\n");
        Console.WriteLine("\n");
        
        StorageDrawFacade.Draw((10, 7));
    }
}
    
