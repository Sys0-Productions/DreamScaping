// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal/ReportMethods.cs
// Created: 2022-05-26-9:27 PM
// *********************************************************************************************************************

namespace Levels.Universal
{
public partial class /*.*/ Report {
	public void /*.*/ Add<T> (
		T report)
	where T : Report {
		var last = GetLast(this);
		last.Next = report;
	}

	private Report GetLast (
		Report report) {
		return report.Next == null
				   ? report
				   : GetLast(report.Next);
	}

	private static Report PullFromPool (
		string message
	  , object source
	  , Report next = null) {
		return Report.Setup(
			Report.Pool.Pull()
		  , message
		  , source
		  , next);
	}

	private static T PullFromPool<T> (
		string message
	  , object source
	  , Report next = null)
	where T : Report {
		return Report.Setup(
				   Report.Pool.Pull()
				 , message
				 , source
				 , next) as T;
	}

	public static Report /*.*/ Setup (
		Report rep
	  , string message
	  , object source
	  , Report next) {
		rep.Message = message;
		rep.Source  = source;
		rep.Next    = next;

		return rep;
	}
}
}