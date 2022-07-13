using System.Collections.Generic;

namespace Levels.Universal {

public partial class /*.*/ User {
	public partial class /*.*/ Input {
		public class /*.*/ Relay {
			// Variables

			/// <summary>
			/// The container for all controls for the player.
			/// </summary>
			private readonly /*.*/ Dictionary<string, List<Control>> _controlDictionary = new Dictionary<string, List<Control>>();
			public Relay /*.*/ AddControl(
				Control control) {

				if (_controlDictionary.ContainsKey(control.Command))
					_controlDictionary[control.Command].Add(control);
				else
					_controlDictionary.Add(control.Command, new List<Control> { control });

				return this;
			}
			public Relay /*.*/ TryRemoveControl(
				Control control) {

				if (_controlDictionary.ContainsKey(control.Command))
					_controlDictionary[control.Command].Remove(control);

				return this;
			}
			public bool /*.*/ ContainsControl(
				Control control) {

				if (!_controlDictionary.ContainsKey(control.Command))
					return false;

				return _controlDictionary[control.Command].Contains(control);
			}


			/// <summary>
			/// Will relay the current command to all controls that are listening for it.
			/// </summary>
			/// <param name="command"> The command being invoked.</param>
			/// <returns>this</returns>
			public Relay /*.*/ RelayCommand(
				string command) {

				if (!_controlDictionary.ContainsKey(command))
					return this;

				for (int i = 0;i < _controlDictionary[command].Count;i++) {
					_controlDictionary[command][i].PassCommand();
				}

				return this;
			}
		}

		public partial class /*.*/ Control { }
	}
}
}

