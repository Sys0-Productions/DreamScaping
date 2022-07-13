// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/ReportPool.cs
// Created: 2022-05-26-5:52 PM
// *********************************************************************************************************************

namespace Levels.Universal {
using System.Collections.Generic;

using Levels.Universal;

public partial class /*.*/ Report {
	public class Pool {
		// TODO: Change to DI
		private static Report.Pool _service;

		// Linked node chain, only pull/add from the top of a stack.
		private readonly Stack<Report> _reportPoolStack = new Stack<Report>();

		public Pool() {
			// TODO: Change to DI
			_service = this;
		}

		public static Report /*.*/ Pull() {
			if (_service._reportPoolStack.Count == 0)
				return new Report();

			var holder = _service._reportPoolStack.Pop();

			return holder;
		}
	}
}
}