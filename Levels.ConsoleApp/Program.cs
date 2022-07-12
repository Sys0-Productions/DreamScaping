using Grace.DependencyInjection;

using Levels.ConsoleApp.Engine;
using Levels.ConsoleApp.Frames;
using Levels.ConsoleApp.UserExperience;
using Levels.Universal.Engine;

using static Levels.ConsoleApp.Engine.EngineStates;

using Engine = Levels.Universal.Engine.Engine;

class Program
{
    static async Task Main(string[] args) {
		// int DebugCode = Program.CodeCleaner(args);
		int DebugCode = 0;
		Console.WriteLine(DebugCode);

		// string flags  = Program.FlagCleaner(args);
		string flags = "R";

		var container        = new DependencyInjectionContainer();
		
		Console.WriteLine("Variables Setup");

		// Initialize
		Console.WriteLine(container.ScopeId);

		container.
			ConfigUserExperience().
			ConfigFrameManager().
			ConfigEngine().
			ConfigUpdatePipeline();

		container.
			Locate<FrameManager>().
				  MainEngine = container.Locate<Engine>();

		container.Locate<UpdatePipeline>().AddUpdate(new Update.ReadInput(from: container.Locate<UserExperience>().GetInputBinds()));

		var engine = container.
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