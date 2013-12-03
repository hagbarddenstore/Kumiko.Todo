namespace Kumiko.Todo.Domain.Items
{
	using System;

	public class Item
	{
		public Item(string content)
		{
			Id = Guid.NewGuid();
			CreatedOn = TimeFactory.CurrentUtc();
			Content = content;
			Status = Status.Undone;
		}

		public Guid Id { get; private set; }

		public DateTime CreatedOn { get; private set; }

		public string Content { get; private set; }

		public Status Status { get; private set; }

		public void MarkAsDone()
		{
			Status = Status.Done;
		}
	}
}
