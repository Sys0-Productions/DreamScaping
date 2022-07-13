// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal/Reports.cs
// Created: 2022-05-26-5:42 PM
// *********************************************************************************************************************

namespace Levels.Universal {
using Levels.Universal.ReportCodes.Core;

public partial class /*.*/ Report : IReport {
	public string /*.*/ Message;
	public object /*.*/ Source;
	public Report /*.*/ Next;

	public Report() {}

	public Report (
		string message
	  , object source
	  , Report next = null) {

		Message = message;
		Source  = source;
		Next    = next;
	}
}
}