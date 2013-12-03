namespace Kumiko.Todo.Domain
{
	using System;

	public static class TimeFactory
	{
		public static DateTime CurrentUtc()
		{
			return DateTime.UtcNow;
		}
	}
}
