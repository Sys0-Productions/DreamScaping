// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.ConsoleApp/FrameResult.cs
// Created: 2022-06-19-1:04 AM
// *********************************************************************************************************************

using Levels.ConsoleApp;

namespace Levels.Engine.Frames; 
public struct FrameResult {
	/// <summary>
	/// The state the engine is currently in.
	/// </summary>
	private EngineStates _state;
		public EngineStates /*.*/ ViewState()=> _state;
		public bool         /*.*/ isRunning()=> _state == EngineStates.isRunning;
		public FrameResult  /*.*/ SetState(
			EngineStates state) {
			_state = state;

			return this;
		}


	/// <summary>
	/// The number of frames we want per second.
	/// </summary>
	private int _targetFrameCount;
	public int         /*.*/ GetTargetFrameCount()=>_targetFrameCount;
	public FrameResult /*.*/ SetTargetFrameCount(
		int setToValue) {
		_targetFrameCount = setToValue;

		return this;
	}
}
