// See https://aka.ms/new-console-template for more information

using System.Text;
using ExtensionMethods;
using Levels.ConsoleApp.Visualizers.Storage;
using Levels.UnityFramework.Storage;
using MyNamespace;
using UnityEngine;


class Program
{
    static void Main(string[] args)
    {
        StorageDrawFacade.Draw(new Vector2(2, 2));

        StorageDrawFacade.Draw(new Vector2(2, 3));

        StorageDrawFacade.Draw(new Vector2(2, 5));

        StorageDrawFacade.Draw(new Vector2(20, 6));

        StorageDrawFacade.Draw(new Vector2(10, 7));
    }
}
    
