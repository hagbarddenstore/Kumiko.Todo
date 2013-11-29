namespace Kumiko.Todo
{
	using System;
	using System.Linq;
	using System.Threading;

	using Nancy;
	using Nancy.Hosting.Self;

	public static class Program
	{
		public static void Main(string[] args)
		{
			var uri = new Uri("http://localhost:9100/");
			Console.WriteLine("Starting server on {0}", uri);

			var host = new NancyHost(uri);

			host.Start();

			if (args.Any(x => x.Equals("-d", StringComparison.CurrentCultureIgnoreCase)))
			{
				Thread.Sleep(Timeout.Infinite);
			}
			else
			{
				Console.ReadLine();
			}

			host.Stop();
		}
	}
}
