using ClassicOldGames.Data;
using ClassicOldGames.Interface;
using System.Collections.Generic;

namespace ClassicOldGames.Repository
{
	class VideoGameRepository : IRepository<VideoGame>
	{
		private List<VideoGame> gameList = new List<VideoGame> ();
		public List<VideoGame> List => gameList;

		public int NextId => gameList.Count;

		public VideoGame GetItemByID (int id)
		{
			return gameList.Find (game => game.Id == id);
		}

		public bool Contains (int id)
		{
			return GetItemByID (id) != null;
		}

		public bool Insert (VideoGame entity)
		{
			if (Contains (entity.Id))
				return false;

			gameList.Add (entity);

			return true;
		}

		public bool Remove (int id)
		{
			if (Contains (id))
			{
				gameList[id].SetRemoved (true);
				return true;
			}

			return false;
		}

		public bool Update (int id, VideoGame entity)
		{
			if (Contains (id))
			{
				gameList[id] = entity;
				return true;
			}

			return false;
		}
	}
}
