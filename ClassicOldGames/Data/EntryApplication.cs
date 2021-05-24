using System;

namespace ClassicOldGames.Data
{
	class EntryApplication : BaseEntity
	{
		public string Title { get; protected set; }
		public string Description { get; protected set; }
		public int ReleaseYear { get; protected set; }
		public bool Available { get; protected set; }

		public void SetAvailability (bool status) => Available = status;
	}
}
