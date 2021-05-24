using ClassicOldGames.Data;
using ClassicOldGames.Enums;
using ClassicOldGames.Repository;
using System;
using System.Collections.Generic;

namespace ClassicOldGames
{
	class Program
	{
		static VideoGameRepository gameRepo = new VideoGameRepository ();

		static void Main (string[] args)
		{
			CreateMockupGameList ();

			ProcessUserInput ();
		}

		#region * MOCKUP *

		private static void CreateMockupGameList ()
		{
			AddMockupGame ("DOOM", 1993, Genre.Action, "Id Software", "Id Software", true, false, "A space marine is sent to investigate strange messages coming from a radioactive waste facility on Mars, only to find out it was overriden with deadly demons and the possessed bodies of the habitants. Alone, he must fight his way out the place and kill everything in his path.");

			AddMockupGame ("Half-Life", 1998, Genre.Action, "Valve", "Sierra Studios", true, false, "During a experiment, physist Gordon Freeman opens a portal to another dimension severely damaging the facility in proccess. Amidst the chaos, Freeman needs to defend himself from opposing forces sent to clean and silence all remaining personnel while fighting against aliens from Xen.");

			AddMockupGame ("Deus-Ex", 2000, Genre.Action, "Ion Storm", "Eidos Interactive", true, false, "Taking place in 2052, agent JC Denton is a augmented human with nanotecnology. Alongside his brother, they joyined the UNATCO to avenge their parents' deaths but ended getting caught in a net of conspiracies involving megacorporations, secret organizations, world leaders and terrorists.");

			AddMockupGame ("Fallout 2", 1998, Genre.RolePlaying, "Black Isle Studios", "Bethesda Softworks", true, false, "It's been 80 long years since your ancestors trod across the wastelands. As you search for the Garden of Eden Creation Kit to save your primitive village, your path is strewn with crippling radiation, megalomaniac mutants, and a relentless stream of lies, deceit and treachery. You begin to wonder if anyone really stands to gain anything from this brave new world.");

			AddMockupGame ("Theme Hospital", 1997, Genre.Strategy, "Bullfrog Productions", "Electronic Arts", true, false, "Theme Hospital is a level-based hospital management simulation where players have to start on an empty building, and then assemble rooms with all kinds of material, from desks and file cabinets for the general diagnosis to the expensive ultra-scanners and x-rays to diagnose such bizarre diseases such as Bloaty Head, Slack Songue or Alien DNA, and treat them with with even more bizarre machines like an Head Inflator or a DNA fixer.");
		}

		private static void AddMockupGame (string title, int releaseYear, Genre genre, string developer, string publisher, bool singlePlayer, bool multiPlayer, string description)
		{

			VideoGame videoGame = new (
				id: gameRepo.NextId,
				title: title,
				releaseYear: releaseYear,
				genre: genre,
				developer: developer,
				publisher: publisher,
				singlePlayer: singlePlayer,
				multiPlayer: multiPlayer,
				description: description
				);

			gameRepo.Insert (videoGame);
		}

		#endregion

		#region * USER INPUT *

		private static void DisplayOptionsMenu ()
		{
			Console.WriteLine ();
			Console.WriteLine ("Classic Old Games");
			Console.WriteLine ("Select your desired action:");

			Console.WriteLine ("1- List games");
			Console.WriteLine ("2- Insert new game");
			Console.WriteLine ("3- Update existing game");
			Console.WriteLine ("4- Remove game");
			Console.WriteLine ("5- Diplay game info");
			Console.WriteLine ("C- Clear screen");
			Console.WriteLine ("X- Exit");
		}

		private static string GetUserInput ()
		{
			DisplayOptionsMenu ();

			string userInput = Console.ReadLine ().ToUpper ();
			Console.WriteLine ();
			return userInput;
		}

		private static void ProcessUserInput ()
		{
			string input = GetUserInput ();

			while (input != "X")
			{
				switch (input)
				{
					case "1":
						GetGamesList ();
						break;
					case "2":
						InsertGame ();
						break;
					case "3":
						UpdateGame ();
						break;
					case "4":
						RemoveGame ();
						break;
					case "5":
						DisplayGame ();
						break;
					case "C":
						Console.Clear ();
						break;
					default:
						throw new ArgumentOutOfRangeException ();
				}

				input = GetUserInput ();
			}

			Console.WriteLine ("Application closed.");
		}

		#endregion

		#region * MENU OPTIONS *

		private static void GetGamesList ()
		{
			Console.WriteLine ("Games List:");
			var list = gameRepo.List;

			if (list.Count == 0)
			{
				Console.WriteLine ("No games found.");
				return;
			}

			foreach (var game in list)
			{
				var removed = (game.Removed) ? " * Excluded * " : "";
				Console.WriteLine ("#ID {0}: - {1} ({2}) {3}", game.Id, game.Title, game.ReleaseYear, removed);
			}
		}

		private static void InsertGame ()
		{
			VideoGame newGame = GetGame (gameRepo.NextId);

			bool status = gameRepo.Insert (newGame);

			if (status)
			{
				Console.WriteLine ("Game successfully added to repository.");
			}
			else
			{
				Console.WriteLine ("Failed to insert game to repository.");
			}
		}

		private static void UpdateGame ()
		{
			Console.Write ("Digit game ID: ");
			int idInput = int.Parse (Console.ReadLine ());

			VideoGame game = GetGame (idInput);

			bool status = gameRepo.Update (idInput, game);

			if (status)
			{
				Console.WriteLine ("Game successfully updated.");
			}
			else
			{
				Console.WriteLine ("Failed to update game.");
			}
		}

		private static void RemoveGame ()
		{
			Console.Write ("Digit game ID: ");
			int idInput = int.Parse (Console.ReadLine ());

			bool status = gameRepo.Remove (idInput);

			if (status)
			{
				Console.WriteLine ("Game successfully removed.");
			}
			else
			{
				Console.WriteLine ("Failed to remove game.");
			}
		}

		private static void DisplayGame ()
		{
			Console.Write ("Digit game ID: ");
			int idInput = int.Parse (Console.ReadLine ());

			var game = gameRepo.GetItemByID (idInput);

			if (game == null)
			{
				Console.WriteLine ("Game with ID {0} not found.", idInput);
				return;
			}
			else
			{
				Console.WriteLine (game.ToString ());
			}
		}

		private static VideoGame GetGame (int id)
		{
			Console.Write ("Insert TITLE: ");
			string inputTitle = Console.ReadLine ();

			Console.Write ("Insert RELEASE YEAR: ");
			int inputYearRelease = int.Parse (Console.ReadLine ());

			Console.WriteLine ("Available genres:");
			foreach (int i in EnumUtil.GetValues<Genre> ())
			{
				Console.WriteLine ("{0} - {1}", i, EnumUtil.GetName<Genre> (i));
			}

			Console.Write ("Insert GENRE: ");
			int inputGenre = int.Parse (Console.ReadLine ());

			if (inputGenre >= EnumUtil.Count<Genre> ())
			{
				Console.WriteLine ("Genre code not recognized.");
				return null;
			}

			Console.Write ("Insert DEVELOPER: ");
			string inputDeveloper = Console.ReadLine ();

			Console.Write ("Insert PUBLISHER: ");
			string inputPublisher = Console.ReadLine ();

			Console.Write ("Insert DESCRIPTION: ");
			string inputDescription = Console.ReadLine ();

			Console.Write ("Does the game have a singleplayer mode? (Y|N): ");
			bool inputSinglePlayer = Console.ReadLine ().ToUpper() == "Y";

			Console.Write ("Does the game have a multiplayer mode? (Y|N): ");
			bool inputMultiPlayer = Console.ReadLine ().ToUpper () == "Y";

			VideoGame videoGame = new (
				id: id,
				title: inputTitle,
				releaseYear: inputYearRelease,
				genre: (Genre)inputGenre,
				developer: inputDeveloper,
				publisher: inputPublisher,
				singlePlayer: inputSinglePlayer,
				multiPlayer: inputMultiPlayer,
				description: inputDescription
				);

			return videoGame;
		}

		#endregion
	}
}
