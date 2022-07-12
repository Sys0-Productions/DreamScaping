using Grace.DependencyInjection;

using Levels.Universal.Engine;

namespace Levels.ConsoleApp.Engine; 
public static class DIEngine {
	public static DependencyInjectionContainer ConfigEngine(
		this DependencyInjectionContainer DI) {
		DI.Configure(
			c => 
				c.ExportInstance(new Universal.Engine.Engine(DI.Locate<FrameManager>())));

		return DI;
	}
}
