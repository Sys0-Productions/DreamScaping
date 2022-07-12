﻿using static Levels.Universal.UserExperience;

namespace Levels.Universal {

public interface IUserExperience {
	public UserExperience.InputBinds GetInputBinds();
}

public partial class UserExperience : IUserExperience {
	private InputBinds _inputBindsService;

	public InputBinds GetInputBinds()=> _inputBindsService;

	public UserExperience (
		InputBinds inputBindsService) {
		_inputBindsService = inputBindsService;
	}

	public class InputBinds {
		public static ConsoleKey ValidKeys;

		/// <summary>
		/// The public report of the last method call.
		/// </summary>
		public Report CurrentReport;

		/// <summary>
		/// List of main keys.
		/// </summary>
		private ConsoleKey KeyCombos;

		public InputBinds[] InputBindings;

		/// <summary>
		/// Tr
		/// </summary>
		/// <param name="from"></param>
		/// <returns></returns>
		public InputBinds tryAddBind (

			// Variables
			ConsoleKey[] from) {

			// Logic
			ValidateNewBindIn(from);

			// Validate the bind

			return this;
		}

		public Report ValidateNewBindIn (
			ConsoleKey[] inputs) {
			// Check what keys where passed are valid.

			// Check that there 

			return new Report();
		}
	}
}
}