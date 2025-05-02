using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace MMA_Tracker
{
	
	internal class Config
	{
		public static IConfigurationRoot Configuration { get; }

		static Config()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(AppContext.BaseDirectory)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			Configuration = builder.Build();
		}
		public static string GetConnectionString(string name)
		{
			return Configuration.GetConnectionString(name);
		}

	}
}
