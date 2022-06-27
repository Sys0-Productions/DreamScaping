﻿using Grace.DependencyInjection;

namespace Levels.Universal.Engine; 
public static class DIUpdatePipeline {
	public static DependencyInjectionContainer ConfigUpdatePipeline(
		this DependencyInjectionContainer DI) {

		DI.Configure(
			c => c.ExportInstance(new UpdatePipeline()));

		return DI;
	}
}