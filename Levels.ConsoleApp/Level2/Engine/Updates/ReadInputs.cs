using static Levels.Universal.UserExperience;

namespace Levels.Universal {
public partial class Update {
	public class /*.*/ ReadInput : Update {
		// Variables
		public override bool /*.*/ isContinuous() => true;
		public override bool /*.*/ ShouldRestart()=> true;
		public override bool /*.*/ isAsync()      => true;

		private UserExperience.InputBinds _inputBinds;

		// Initialization
		public ReadInput (
			UserExperience.InputBinds from) {

			_inputBinds = from;
		}

		// Logic

		public ReadInput Invoke<T> (
			T withData) {
			while (checkKeysPressed(
					   Console.ReadKey().
							   Key));

			return this;
		}

		private bool checkKeysPressed (
			ConsoleKey key) {
			throw new NotImplementedException();
		}
	}
}
}