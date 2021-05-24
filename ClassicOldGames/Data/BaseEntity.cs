
namespace ClassicOldGames.Data
{
	class BaseEntity
	{
		public int Id { get; protected set; }
		public bool Removed { get; protected set; }

		public void SetRemoved (bool status)
		{
			Removed = status;
		}
	}
}
