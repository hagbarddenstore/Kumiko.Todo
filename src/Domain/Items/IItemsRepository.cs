namespace Kumiko.Todo.Domain.Items
{
	using System;
	using System.Collections.Generic;

	public interface IItemsRepository
	{
		void Save(Item item);

		void Delete(Guid id);

		Item Find(Guid id);

		IEnumerable<Item> FindAll();
	}
}
