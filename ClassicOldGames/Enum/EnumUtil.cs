using System;

namespace ClassicOldGames.Enums
{
	public static class EnumUtil
	{
		public static Array GetValues<T> () => Enum.GetValues (typeof (T));

		public static string GetName<T> (object i) => Enum.GetName (typeof (T), i);

		public static int Count<T> () => GetValues<T> ().Length;
	}
}
