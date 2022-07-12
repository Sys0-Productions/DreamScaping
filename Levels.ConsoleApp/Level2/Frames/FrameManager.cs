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

	public int /*.*/ TargetFramePerSecond = 144;

	/// <summary>
	/// The report of the frames status.
	/// </summary>
	public Report /*.*/ FrameReport;

	private Stopwatch _watch;
	private Stopwatch _watchTest;

		private UpdatePipeline _updatePipeline;

	int count = 0;

	public FrameManager (
		UpdatePipeline updatePipeline) {

		_updatePipeline = updatePipeline;
		_consoleKeyTask = Task.Run(
			() => {
				MonitorKeypress(new CancellationTokenSource());
			});
		_watch     = new Stopwatch();
		_watchTest = new Stopwatch();

		_watchTest.Start();
	}

	private bool _keyReadout = false;
	private Task _consoleKeyTask;

	/// <summary>
	/// Runs the current frame.
	/// </summary>
	public async Task RunFrame() {
		_watch.Restart();
		

		if (!_keyReadout) {

			_consoleKeyTask.Start();
		}

		// Source: https://stackoverflow.com/questions/26716006/using-await-task-delay-in-a-for-kills-performance?rq=1
		/*
		var elapsed = Stopwatch.StartNew();
		var delay = TimeSpan.FromMilliseconds(1000 / TargetFramePerSecond); // a call should happen every 1000 / numberOfCallsPerSecond milliseconds
		int expectedI = 0;
		for (int i = 0;i < TargetFramePerSecond;i++) {
			expectedI = (int)elapsed.Elapsed.TotalSeconds * TargetFramePerSecond;

			if (i > expectedI)
				await Task.Delay(delay);
		}*/

		count++;


		// TODO: Try making an artificial delay from something like running math problem x times, causing x delay.
		// Possible Alternative to look into.
		// https://gamedev.stackexchange.com/questions/150287/proper-use-of-async-await-and-task-delay-for-a-game-loop
		var lengthForFrameTime = Math.Max((int)((1000f / 60f) - _watch.ElapsedMilliseconds) - 20, 1);
		await Task.
			  Delay(lengthForFrameTime);

		if (_watchTest.ElapsedMilliseconds >= 1000) {
			Console.WriteLine("FRAME: " + count);
			count = 0;
			_watchTest.Restart();
		}
	}
	
	public void MonitorKeypress(CancellationTokenSource cancellationToken) {
		//Sources:
		//https://darchuk.net/2019/02/08/waiting-for-a-keypress-asynchronously-in-a-c-console-app/
		//https://www.delftstack.com/howto/csharp/wait-for-keypress-csharp/
		_keyReadout = true;

		Console.WriteLine("Capture Key");
		ConsoleKeyInfo cki = new ConsoleKeyInfo();
		do { 
			// Hides the pressed key
			cki = Console.ReadKey(true);

			Console.WriteLine(
				"Keypress: "
			  + cki.KeyChar.ToString().ToUpper());

				// Wait for an ESC
		} while (cki.Key != ConsoleKey.Escape);

		_keyReadout = false;
		// Cancel the token
		cancellationToken.Cancel();
	}

}

}
