namespace Levels.Universal.UserExperience {
using Grace.DependencyInjection;

using Universal;

public static class DIUserExperience {
	public static DependencyInjectionContainer ConfigUserExperience(
		this DependencyInjectionContainer DI) {

		DI.Configure(
			c => c.ExportInstance(new User.Experience(new User.Experience.InputBinds())));

		return DI;
	}
}
}
