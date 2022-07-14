namespace Levels.Universal {
public partial class Update {
	public class /*.*/ ReadInput : Update {
		// Variables
		public override bool /*.*/ isContinuous() => true;
		public override bool /*.*/ ShouldRestart()=> true;
		public override bool /*.*/ isAsync()      => true;

		private User.Experience.InputBinds _inputBinds;

		// Initialization
		public ReadInput (
			User.Experience.InputBinds from) {

			_inputBinds = from;
		}

		// Logic

		public ReadInput Invoke<T> (
			T withData) {
			while (checkKeysPressed(
					   Console.ReadKey().
							   Key))
				;

			return this;
		}

		private bool checkKeysPressed (
			ConsoleKey key) {
			throw new NotImplementedException();
		}
	}
}
}