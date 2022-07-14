using Levels.ConsoleApp;

// TODO: Change namespace
namespace Levels.Universal {

using static EngineStates;

public partial class /*.*/ Engine {
	//Variables

	/// <summary>
	/// The state of the engine
	/// </summary>
	private EngineStates _currentState;
	public EngineStates /*.*/ State()=> _currentState;
	public EngineStates /*.*/ SetState (
		EngineStates newState)=> _currentState = newState;

	/// <summary>
	/// The Manager for this whole project.
	/// </summary>
	public readonly FrameManager /*.*/
		FrameManager;

	// Initialization
	public Engine (
		FrameManager frameManager) {
		FrameManager = frameManager;
	}

	// Methods

	/// <summary>
	/// Puts the engine in a Start state.
	/// </summary>
	/// <returns>this</returns>
	public Engine /*.*/ Start() {
		_currentState = isStarting;

		return this;
	}

	public Engine /*.*/ Shutdown() {
		_currentState = isRunning;

		return this;
	}

	public Engine /*.*/ Quit() {
		_currentState = isStarting;

		return this;
	}

	/// <summary>
	/// syntactical way of indicating intention.
	/// </summary>
	/// <returns></returns>
	public FrameManager /*.*/ CallOnFrameManager()=> FrameManager;
}
}
