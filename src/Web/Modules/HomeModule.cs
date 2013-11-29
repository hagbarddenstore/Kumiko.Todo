namespace Kumiko.Todo.Web.Modules
{
	using Nancy;

	public class HomeModule : NancyModule
	{
		public HomeModule()
		{
			Get["/"] = parameters => "Hello, world!";
		}
	}
}
