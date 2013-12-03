namespace Kumiko.Todo.Web.Modules
{
	using System;

	using Nancy;

	public class HomeModule : NancyModule
	{
		public HomeModule()
		{
			StaticConfiguration.DisableErrorTraces = true;

			Get["/"] = Home;
		}

		private dynamic Home(dynamic parameters)
		{
			Console.WriteLine("I am alive!");

			try
			{
				return View["Index"];
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception.Message);

				return exception.Message;
			}
		}
	}
}
