namespace Kumiko.Todo.Web
{
	using Nancy;
	using Nancy.Bootstrapper;
	using Nancy.TinyIoc;

	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
			StaticConfiguration.DisableErrorTraces = true;
		}
	}
}
