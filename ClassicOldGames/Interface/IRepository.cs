using System.Collections.Generic;

namespace ClassicOldGames.Interface
{
	interface IRepository<T>
	{
		List<T> List { get; }

		bool Contains (int id);

		T GetItemByID (int id);

		bool Insert (T entity);

		bool Remove (int id);

		bool Update (int id, T entity);

		int NextId { get; }
	}
}
