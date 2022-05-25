// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/StorageDrawFacade.cs
// Created: 2022-05-24-9:08 PM
// *********************************************************************************************************************

using System.Text;
using ExtensionMethods;
using Levels.ConsoleApp.Visualizers.Storage;
using Levels.UnityFramework.Storage;
using UnityEngine;

namespace MyNamespace
{
    class StorageDrawFacade
    {
        public static void Draw(Vector2 size)
        {
            Console.WriteLine(StorageTxtVis.Draw(
                new StorageMatrix(size),
                new List<StringBuilder>().FillWithNew((int)size.y * 2 - 1).ToArray(),
                new StorageStylizer()));
        }
    }
}
