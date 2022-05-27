// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/ReportPool.cs
// Created: 2022-05-26-5:52 PM
// *********************************************************************************************************************

using System.Collections.Generic;
using Levels.Universal;

public class ReportPool
{
    private static ReportPool service;
    // Linked node chain, only pull/add from the top of a stack.
    private readonly Stack<Report> _reportPoolStack = new Stack<Report>();

    public static Report PullSetup(string message, object source = null, Report next = null)
    {
        if (service._reportPoolStack.Count == 0)
            return new Report(message, source, next);
        
        var holder = service._reportPoolStack.Pop();
        return Report.Setup(holder, message, source, next);
    }

    public static void StartReport()
    {
        
    }
}