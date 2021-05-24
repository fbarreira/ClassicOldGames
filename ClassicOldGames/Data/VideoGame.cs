using ClassicOldGames.Enums;
using System;
using System.Collections.Generic;

namespace ClassicOldGames.Data
{
	class VideoGame : EntryApplication
	{
		public Genre Genre { get; private set; }
		public string Developer { get; private set; }
		public string Publisher { get; private set; }
		public bool Singleplayer { get; private set; }
		public bool Multiplayer { get; private set; }

		public VideoGame (int id, string title, int releaseYear, Genre genre, string developer, string publisher, string description, bool singlePlayer, bool multiPlayer)
		{
			Id = id;
			Title = title;
			ReleaseYear = releaseYear;
			Genre = genre;
			Developer = developer;
			Publisher = publisher;
			Description = description;
			Singleplayer = singlePlayer;
			Multiplayer = multiPlayer;
			Available = true;
		}

		public override string ToString ()
		{
			string result = "";
			result += string.Format ("{0} ({1})", Title, ReleaseYear) + Environment.NewLine;
			result += string.Format ("Developer: {0}", Developer) + Environment.NewLine;
			result += string.Format ("Publisher: {0}", Publisher) + Environment.NewLine;
			result += string.Format ("Genre: {0}", Genre) + Environment.NewLine;
			result += string.Format ("Description: {0}", Description) + Environment.NewLine;
			result += string.Format ("SinglePlayer: {0}", Singleplayer) + Environment.NewLine;
			result += string.Format ("MultiPlayer: {0}", Multiplayer) + Environment.NewLine;
			result += string.Format ("Available: {0}", Available) + Environment.NewLine;
			result += string.Format ("Removed: {0}", Removed) + Environment.NewLine;
			return result;
		}
	}
}
