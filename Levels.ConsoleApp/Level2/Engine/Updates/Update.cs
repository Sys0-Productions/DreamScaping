using static Levels.Universal.UserExperience;

namespace Levels.Universal {
public partial class /*.*/ Update {
	/// <summary>
	/// The Report of the last call method on this function.
	/// </summary>
	public Report UpdateReport;

	/// <summary>
	/// A continuous async task will keep going past a frame.
	/// </summary>
	/// <returns></returns>
	public virtual bool /*.*/ isContinuous()=> false;
	public virtual bool /*.*/ ShouldRestart()=> false;
	public virtual bool /*.*/ isAsync()      => false;

	public virtual Task /*.*/ RunAsync() {
		return Task.Run( () => {
			 int x = 2 + 2;});
	}
	public virtual void /*.*/ RunParallel() {
		var x = 2 + 2;
	}
}
}
