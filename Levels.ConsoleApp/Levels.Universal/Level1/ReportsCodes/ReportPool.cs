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

    public ReportPool()
    {
        // TODO: Make good.
        service = this;
    }

    public static Report Pull()
    {
        if (service._reportPoolStack.Count == 0)
            return new Report();
        
        var holder = service._reportPoolStack.Pop();
        return holder;
    }

    public static void StartReport()
    {
        
    }
}