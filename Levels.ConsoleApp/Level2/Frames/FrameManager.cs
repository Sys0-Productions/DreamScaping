using static Levels.Universal.Engine.UserExperience;
using System.Diagnostics;

using Levels.ConsoleApp.Engine;
using Levels.Engine.Frames;

namespace Levels.Universal.Engine {
/// <summary>
/// The manager for the frame of an engine.
/// </summary>
public class FrameManager {
	public Update[] /*.*/ AllUpdates;

	public Engine /*.*/ MainEngine;

	/// <summary>
	/// The report of the frames status.
	/// </summary>
	public Report /*.*/ FrameReport;

	private UpdatePipeline _updatePipeline;

	int count = 0;

	public FrameManager (
		UpdatePipeline updatePipeline) {
		_updatePipeline = updatePipeline;
	}

	/// <summary>
	/// Runs the current frame.
	/// </summary>
	public async Task RunFrame() {
		var watch = new Stopwatch();
		watch.Start();

		count++;
		Console.WriteLine("Frame " + count + " " + watch.ElapsedMilliseconds);
		//Thread.Sleep(1000);
		await Task.Delay(1000);
		Console.WriteLine("Frame " + count + " " + watch.ElapsedMilliseconds);

		// Variables
			//while (true) {
			//watch.Reset();

			//Console.WriteLine("Frame " + count + " " + watch.ElapsedTicks);
			//count++;

			// Initialization
			//watch.Start();

			//await Task.Delay(0);

			//frameData.SetState(EngineStates.isRunning);

			//await _updatePipeline.RunUpdatesAsync();

			//var lengthForFrameTime = (int)(((float)1 / 144 * 1000) - (float)watch.ElapsedMilliseconds);

			//await Task.
			//	  Delay(lengthForFrameTime).
			//	  ConfigureAwait(continueOnCapturedContext: false);

			//Console.WriteLine(watch.ElapsedMilliseconds);
			//Console.WriteLine(watch2.ElapsedMilliseconds);

			//MainEngine.SetState(EngineStates.isRunning);
			//}
		}

		public void RunAllUpdates() {

	}
}
}
