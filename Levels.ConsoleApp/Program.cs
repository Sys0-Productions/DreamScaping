using Grace.DependencyInjection;

using Levels.ConsoleApp;
using Levels.ConsoleApp.Frames;
using Levels.Universal;
using Levels.Universal.UserExperience;

using static Levels.ConsoleApp.EngineStates;

using Engine = Levels.Universal.Engine;

class Program {
	static async Task Main (
		string[] args) {
		// int DebugCode = Program.CodeCleaner(args);
		int DebugCode = 0;
		Console.WriteLine(DebugCode);

		// string flags  = Program.FlagCleaner(args);
		string flags = "R";

		var containerDI = new DependencyInjectionContainer();

		Console.WriteLine("Variables Setup");

		// Initialize
		Console.WriteLine(containerDI.ScopeId);

		containerDI.
			ConfigUserExperience().
			ConfigFrameManager().
			ConfigEngine().
			ConfigUpdatePipeline();

		containerDI.
			Locate<FrameManager>().
			MainEngine = containerDI.Locate<Engine>();

		containerDI.Locate<UpdatePipeline>().
				  AddUpdate(
					  new Update.ReadInput(
						containerDI.Locate<User.Experience>().
							GetInputBinds()));

		var engine = containerDI.
					 Locate<Engine>().
					 Start();

		Console.WriteLine("Initialize Setup");

		// Logic

		if (flags.Contains("R")) {
			while (true) {
				await engine.FrameManager.RunFrame();

				if (engine.State() == isStarting) {
					engine.SetState(EngineStates.isRunning);

				}
			}
		}
	}
}