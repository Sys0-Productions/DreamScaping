// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal/EnumerableExtension.cs
// Created: 2022-05-24-2:57 PM
// *********************************************************************************************************************

namespace ExtensionMethods
{
    using System.Collections.Generic;

    public static class Extensions
    {
        public static List<T> FillWithNew<T>(this List<T> list, int count) where T : new()
        {
            for (int i = 0; i < count; i++)
            {
                list.Add(new T());
            }
            
            return list;
        }
    }
}