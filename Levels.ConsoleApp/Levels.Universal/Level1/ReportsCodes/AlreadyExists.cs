// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal/AlreadyExists.cs
// Created: 2022-05-26-5:48 PM
// *********************************************************************************************************************

namespace Levels.Universal
{
    public class AlreadyExists : Report { }
    
    public partial class Report
    {
        public static AlreadyExists AlreadyExists(string message = "", object source = null)
        {
            return Report.PullFromPool<AlreadyExists>(string.IsNullOrEmpty(message) ? "This indicates that something already existed." : message, source, null);
        }
    }
}