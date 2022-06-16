// See https://aka.ms/new-console-template for more information

using Levels.Universal;
using MyNamespace;
using UnityEngine;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            
        }
        
        
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
        
        StorageDrawFacade.Draw((25, 25));
    }
    
    private async void MainFrame_Call(object sender, EventArgs e)
    {
        if (Monitor.TryEnter(sender))
        {
            int fade1 = 1000;
            while (fade1 != -1)
            {
                // Do what ever is on the main frame.

                // Wait for what ever time is left.
                // If extra call out how close we are to a full frame.
                await Task.Delay(30);
                fade1--;
            }
        }
    }
}
    
