// *********************************************************************************************************************
// Created: Sys0 
// Levels.ConsoleApp/Levels.Universal/ArrayFill.cs
// Created: 2022-05-24-4:02 AM
// *********************************************************************************************************************

namespace Levels.Universal.Constructors {
using System.Collections;
using System.Collections.Generic;

public partial class /*.*/ ArrayFuncs<T>
where T : new() {
	private static List<T> array = new List<T>();

	public static ref List<T> /*.*/ FillNew (
		ref List<T> list) {
		for (int i = 0
			 ; i < list.Count
			 ; i++) {
			list[i] = new T();
		}

		return ref list;
	}
}
}