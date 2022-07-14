using Grace.DependencyInjection;

using Levels.Universal;

namespace Levels.ConsoleApp {
public static class DIEngine {
	public static DependencyInjectionContainer ConfigEngine(
		this DependencyInjectionContainer DI) {
		DI.Configure(
			c =>
				c.ExportInstance(new Universal.Engine(DI.Locate<FrameManager>())));

		return DI;
	}
}
}

