// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/Frames.cs
// Created: 2022-06-15-7:05 PM
// *********************************************************************************************************************

namespace Levels.Engine.Frames {
public class /**/Levels {
	public class /*.*/Engine {
		public class /*.*/Frames {
			private async void MainFrame_Call(
				object sender,
				EventArgs e) {
				if (Monitor.TryEnter(sender)) {
					int fade1 = 1000;

					while (fade1 != -1) {
						// Call Initialization Frame
						// Call External Reference Frame(The frame for requesting and injecting external references).
						// Call Physics Update frame.
						// Call Main Update frame.

						// Wait for what ever time is left.
						// If extra call out how close we are to a full frame.
						await Task.Delay(30);
						fade1--;
					}
				}
			}
		}
	}
}
}

