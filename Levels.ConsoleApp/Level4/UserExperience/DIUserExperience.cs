namespace Levels.ConsoleApp.UserExperience {
using Grace.DependencyInjection;

using Levels.Universal.Engine;

public static class DIUserExperience {
	public static DependencyInjectionContainer ConfigUserExperience(
		this DependencyInjectionContainer DI) {

		DI.Configure(
			c => c.ExportInstance(new UserExperience(new UserExperience.InputBinds())));

		return DI;
	}
}
}
