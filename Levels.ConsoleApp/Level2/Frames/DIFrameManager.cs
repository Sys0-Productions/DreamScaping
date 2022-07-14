using Grace.DependencyInjection;

using Levels.Universal;

namespace Levels.ConsoleApp.Frames {
public static class DIFrameManager {
	public static DependencyInjectionContainer ConfigFrameManager(
		this DependencyInjectionContainer DI) {

		DI.Configure(
			c => c.ExportInstance(new FrameManager(DI.Locate<UpdatePipeline>())));

		return DI;
	}
}
}

