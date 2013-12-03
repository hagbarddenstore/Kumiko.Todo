namespace Kumiko.Todo.Web.Modules
{
	using System;

	using Nancy;

	using Kumiko.Todo.Domain.Items;
	using Kumiko.Todo.Domain.Items.Implementations;

	public class ApiModule : NancyModule
	{
		private readonly IItemsRepository _itemsRepository;

		public ApiModule()
		{
			_itemsRepository = new MongoDbItemsRepository();

			Get["/api/v1/items"] = GetItems;
			Get["/api/v1/items/create"] = CreateItem;
			Get["/api/v1/items/{id}/delete"] = DeleteItem;
		}

		private dynamic GetItems(dynamic parameters)
		{
			var items = _itemsRepository.FindAll();
			
			return Response.AsJson(items);
		}

		private dynamic CreateItem(dynamic parameters)
		{
			var item = new Item((string)Request.Query.content);

			_itemsRepository.Save(item);

			return "success";
		}

		private dynamic DeleteItem(dynamic parameters)
		{
			throw new NotImplementedException();
		}
	}
}
