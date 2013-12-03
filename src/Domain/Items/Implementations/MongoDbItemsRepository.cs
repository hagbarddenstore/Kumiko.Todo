namespace Kumiko.Todo.Domain.Items.Implementations
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using MongoDB.Driver;
	using MongoDB.Driver.Builders;

	public class MongoDbItemsRepository : IItemsRepository
	{
		private readonly MongoDatabase _database;

		public MongoDbItemsRepository()
		{
			var url = new MongoUrl("mongodb://localhost/KumikoTodo");
			var client = new MongoClient(url);
			var server = client.GetServer();

			_database = server.GetDatabase(url.DatabaseName);
		}

		public void Save(Item item)
		{
			var collection = GetCollection();

			collection.Save(item);
		}

		public void Delete(Guid id)
		{
			var collection = GetCollection();

			var query = Query.EQ("_id", id);

			collection.Remove(query);
		}

		public Item Find(Guid id)
		{
			var collection = GetCollection();

			var query = Query.EQ("_id", id);

			var item = collection.FindOne(query);
			
			return item;
		}

		public IEnumerable<Item> FindAll()
		{
			var collection = GetCollection();

			var sort = SortBy.Ascending("CreatedOn");

			var query = Query.Or(Query.EQ("Status", Status.Done), Query.EQ("Status", Status.Undone));

			var items = collection.Find(query)
				.SetSortOrder(sort)
				.ToList();

			return items;
		}

		private MongoCollection<Item> GetCollection()
		{
			var collection = _database.GetCollection<Item>("Items");

			return collection;
		}
	}
}
