using System;

namespace Levels.Universal {

public static partial class /*.*/ User {
	public static partial class /*.*/ Input {
		public partial class /*.*/ Control {
			/// <summary>
			/// The string value for the command being invoked.
			/// </summary>
			public string /*.*/
				Command = default!;

			/// <summary>
			/// The action to call when Command is used.
			/// </summary>
			public readonly Action<string> /*.*/
				TargetAction = default!;

			/// <summary>
			/// Will pass the <see cref="Command"/> to the <see cref="TargetAction"/>
			/// </summary>
			/// <param name="command"></param>
			public void /*.*/ PassCommand() {

				TargetAction(Command);
			}
		}
	}
}
}


