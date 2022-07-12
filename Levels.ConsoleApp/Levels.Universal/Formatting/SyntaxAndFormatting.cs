// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal/Syntax.cs
// Created: 2022-06-15-7:14 PM
// *********************************************************************************************************************

// **Namespace formatting area.**
// |Using Levels.Universal.Formatting

// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Threading;
// using System.Threading.Tasks;

// using Grace.DependencyInjection;

// using Levels.Universal;
// using Levels.Universal.DependencyInjection;
// using Levels.Universal.Engine.UserExperience;
// using Levels.Universal.Formatting.ExamplePackage;

// using static Levels.Universal.Engine.Levels.Universal.Engine.UserExperience;
// using static Levels.Universal.Engine.UserExperience;
// using static Levels.Universal.Engine.UserExperience.UserExperience;
// using static Levels.Universal.Formatting.ExampleUsage.Program;
// using static Levels.Universal.Formatting.ExampleUsage.Program.EngineStates;
// using static Levels.Universal.Formatting.ExampleUsage.Program.FrameResult.EngineStates;

// namespace Levels.Universal.Formatting{
// // **This is to indicate the end user experience calling into this(aka how we want to use this).**
// // |Level.package.Feature                                                                                             //Capital.Camel.Case
// public class /**/Level{ public class /*.*/Syntax{ public class /*.*/ PackageName{
//     public class ClassName{
//     // **Then indicates what we are doing**
// // |.MethodName(                                                                                                     //.CapitalCamelCase(
//     public void /*.*/MethodName(
// //**Then show what we are using to call it.**
// // |    parameters,                                                                                             //    flatcase,
//         // Variables
//         string arguement,
// // |    parameters,                                                                                             //    flatcase,
//         string arguement,
// // |    parameters                                                                                              //    flatcase
//         string arguement){
//         
//         
//         
// //**Closing out section**
// // |
// } } } } } }


// // NamingConventions.txt
// //**
// // |*********************************************************************************************************************
// // |Created: Sys0 
// // |Levels.ConsoleApp/Levels.Universal/Syntax.cs
// // |Created: 2022-06-15-7:14 PM
// // |*********************************************************************************************************************
// // |
// // |Using Levels.Universal.Formatting
// // |Level.package.Feature 
// // |    .MethodName(
// // |        Arguement1, 
// // |        Arguement...,
// // |        ArguementN
// // |    .VariableName
// // |        .MethodName(
// // |            Arguement.MethodName(),
// // |)   )   )   )
// //**//


// // ExamplePackage.cs
// namespace Levels.Universal.Formatting.ExamplePackage{
//     public class /*.*/PackageName{
//         public void /*.*/ExampleMethodName/*(*/(
//             int /**/ExamplePerameter1/*,*/, 
//             int /**/ExamplePerameter2/*,*/, 
//             params int[] /**/ExamplePerameterN/*)*/) {
//                 
// }   }   }


// // ExampleUsage.cs
// namespace Levels.Universal.Formatting.ExampleUsage {
// using Engine;

// using Grace.DependencyInjection;

// using static EngineStates;

// public class Program {
// 	public static void /*.*/ Run (
// 		// Variables
// 		int    startDiagnostic = 0
// 	  , string flags           = "R") {
// 		var engine = new Engine();

// 		var updatePipeline = new UpdatePipeline();
// 		var userExperience = new UserExperience(new InputBinds());
// 		var container      = new DependencyInjectionContainer();

// 		container.Configure(
// 			c => c.Export<UserExperience>().As<IUserExperience>());

// 		// Initialize
// 		engine.Start();

// 		// logic
// 		if (flags.Contains("R"))
// 		{
// 			// Logic
// 			while (
// 				//Conditions
// 				engine.State() == isRunning || 
// 				engine.State() == isStarting) /* Then on */
// 				
// 				// Logic
// 				engine.FrameManager.RunFrame();
// 		}
// 	}

// 	public struct FrameResult {
// 		/// <summary>
// 		/// The state the engine is currently in.
// 		/// </summary>
// 		private EngineStates _state;
// 			public EngineStates /*.*/ ViewState()=> _state;
// 			public bool         /*.*/ isRunning()=> _state == EngineStates.isRunning;
// 			public FrameResult  /*.*/ SetState(
// 				EngineStates state) {
// 				_state = state;

// 				return this;
// 			}


// 		/// <summary>
// 		/// The number of frames we want per second.
// 		/// </summary>
// 		private int _targetFrameCount;
// 			public int         /*.*/ GetTargetFrameCount()=>_targetFrameCount;
// 			public FrameResult /*.*/ SetTargetFrameCount(
// 				int setToValue) {
// 				_targetFrameCount = setToValue;

// 				return this;
// 			}
// 	}

// 	public enum EngineStates {
// 		isStarting,
// 		isRunning,
// 		isPaused,
// 		isUnresponsive
// 	}
// 	}
// }

// // Engine.cs
// namespace Levels.Universal.Engine {
// using System.Runtime.CompilerServices;
// using System.Threading.Tasks;

// using static EngineStates;

// public partial class /*.*/Engine {

// 	/// <summary>
// 	/// The state of the engine
// 	/// </summary>
// 	private EngineStates _currentState;
// 	public EngineStates /*.*/State()=> _currentState;

// 	/// <summary>
// 	/// The Manager for this whole project.
// 	/// </summary>
// 	public readonly FrameManager /*.*/FrameManager = new();

// 	/// <summary>
// 	/// Puts the engine in a Start state.
// 	/// </summary>
// 	/// <returns>this</returns>
// 	public Engine /*.*/Start() {
// 		_currentState = isStarting;

// 		return this;
// 	}

// 	/// <summary>
// 	/// syntactical way of indicating intention.
// 	/// </summary>
// 	/// <returns></returns>
// 	public FrameManager /*.*/CallOnFrameManager()=>FrameManager;
// }
// }

// namespace Levels.Universal.Engine {
// /// <summary>
// /// The manager for the frame of an engine.
// /// </summary>
// public class FrameManager {
// 	public Update[] AllUpdates;

// 	/// <summary>
// 	/// The report of the frames status.
// 	/// </summary>
// 	public Report FrameReport;

// 	/// <summary>
// 	/// Runs the current frame.
// 	/// </summary>
// 	public async void RunFrame() {
// 		// Variables
// 		var watch = new Stopwatch();

// 		var frameData = new FrameResult();


// 		userExperience.InputBindsService = new InputBinds();

// 		// Initialization
// 		watch.Start();

// 		updatePipeline.AddUpdate(new Update.ReadInput(from: userExperience.InputBindsService));

// 		frameData.SetState(isRunning);

// 		await updatePipeline.RunUpdatesAsync();

// 		var lengthForFrameTime = (int)(100 / 14400 * 1000) / 100 - (int)watch.ElapsedMilliseconds;
// 		await Task.
// 			  Delay(lengthForFrameTime).
// 			  ConfigureAwait(continueOnCapturedContext: false);
// 	}

// 	public void RunAllUpdates() {

// 	}
// }
// }

// namespace Levels.Universal.Engine {
// public partial class /**/UpdatePipeline {
// 	// Variables
// 	/// <summary>
// 	/// The report for the last called operation.
// 	/// </summary>
// 	public Report    UpdateReport;

// 	// Keeps all the updates called in the Pipeline.
// 	private Update[] _updates;
// 		/// <summary>
// 		/// 
// 		/// </summary>
// 		/// <param name="update"></param>
// 		/// <returns></returns>
// 		public UpdatePipeline AddUpdate(Update update) {
// 			Update[] newUpdates = new Update[_updates.Length + 1];

// 			_updates.CopyTo(newUpdates, 0);
// 			newUpdates[_updates.Length] = update;

// 			return this;
// 		}

// 	public Task RunUpdatesAsync() {
// 		_updateTasks.Invoke();
// 			Task[] asyncTasks = _updates.

// 		return Task.WhenAll(_updateTasksAsync);
// 	}
// }
// }
// }

// namespace Levels.Universal.Engine {
// public partial class /*.*/ Update {
// 	/// <summary>
// 	/// The Report of the last call method on this function.
// 	/// </summary>
// 	public Report UpdateReport;

// 	/// <summary>
// 	/// A continuous async task will keep going past a frame.
// 	/// </summary>
// 	/// <returns></returns>
// 	public virtual bool /*.*/ isContinuous ()=> false;
// 	public virtual bool /*.*/ ShouldRestart()=> false;
// 	public virtual bool /*.*/ isAsync      ()=> false;

// 	public class /*.*/ ReadInput : Update {
// 		// Variables
// 		public override bool /*.*/ isContinuous ()=>true;
// 		public override bool /*.*/ ShouldRestart()=>true;
// 		public override bool /*.*/ isAsync      ()=>true;

// 		private InputBinds _inputBinds;

// 		// Initialization
// 		public ReadInput(
// 			InputBinds from) {

// 			_inputBinds = from;
// 		}

// 		// Logic

// 		public ReadInput Invoke<T>(T withData) {
// 			while (checkKeysPressed(Console.ReadKey().Key));

// 			return this;
// 		}

// 		private bool checkKeysPressed (
// 			ConsoleKey key) {
// 			throw new NotImplementedException();
// 		}
// 	}
// }
// }

// namespace Levels.Universal.Engine {

// public interface IUserExperience {
// 	public InputBinds GetInputBinds();
// }

// public partial class UserExperience : IUserExperience {
// 	private    InputBinds _inputBindsService;

// 	public InputBinds GetInputBinds()=> _inputBindsService;

// 	public UserExperience(
// 		InputBinds inputBindsService) {
// 		_inputBindsService = inputBindsService;
// 	}

// 	public class InputBinds {
// 		public static ConsoleKey ValidKeys;

// 		/// <summary>
// 		/// The public report of the last method call.
// 		/// </summary>
// 		public Report CurrentReport;

// 		/// <summary>
// 		/// List of main keys.
// 		/// </summary>
// 		private ConsoleKey KeyCombos;

// 		/// <summary>
// 		/// Tr
// 		/// </summary>
// 		/// <param name="from"></param>
// 		/// <returns></returns>
// 		public InputBinds tryAddBind(
// 			// Variables
// 			ConsoleKey[] from) {

// 			// Logic
// 			ValidateNewBindIn(from);

// 			// Validate the bind

// 			return this;
// 		}

// 		public Report ValidateNewBindIn(
// 			ConsoleKey[] inputs) {
// 			// Check what keys where passed are valid.

// 			// Check that there 
// 		}
// 	}

// 	public class Service {
// 		public void DoSomething(){}
// 	}

// 	public class InputTrigger {}

// 	public class TODO {}
// }

// public static class DIUserExperience {
// 	public static DependencyInjectionContainer ConfiguerUserExperience (
// 		this DependencyInjectionContainer DI
// 	  , UserExperience                    experience) {
// 		DI.Configure(
// 			c => c.Export<UserExperience>().
// 				   As<IUserExperience>());
// 		DI.
// 		return DI;
// 	}
// }
// }

// // Engine.Builder.CS
// namespace Levels.Universal.Engine{
// public partial class Engine {
// 	public class Builder {
// 		public void BuildServices() {}
// 	}
// }


// // ExamplePackage.cs
// namespace Levels.Universal.Formatting.ExamplePackage {
// using System.Threading.Tasks;

// public class Program {
// 	// Reference to an instance of Program.
// 	// Can now use //using Levels.Universal.Engine static
// 	public Program program;

// 	async Task void CallMain (

// 		// Variables
// 		int    startDiagnostic
// 	  , string flags) {

// 		// Do Things
// 		string.Contains
// 	}
// }
// }