namespace Levels.Universal.Engine {
public partial class /**/UpdatePipeline {
	// Variables
	/// <summary>
	/// The report for the last called operation.
	/// </summary>
	public Report UpdateReport;

	// Keeps all the updates called in the Pipeline.
	private Update[] _updates;
	/// <summary>
	/// 
	/// </summary>
	/// <param name="update"></param>
	/// <returns></returns>
	public UpdatePipeline AddUpdate(
		Update update) {
		int      size  = _updates != null ? _updates.Length + 1 : 1;
		Update[] newUpdates = new Update[size];

		if (_updates != null)
			_updates.CopyTo(newUpdates, 0);
		newUpdates[size - 1] = update;

		_updates = newUpdates;

		return this;
	}

	public Task RunUpdatesAsync() {
		Task[] asyncTasks = new Task[_updates.Length];

		for (int i = 0
			 ; i < _updates.Length
			 ; i++) {
			asyncTasks[i] = _updates[i].
				RunAsync();
		}
	
		return Task.WhenAll(asyncTasks);
	}
}
}
