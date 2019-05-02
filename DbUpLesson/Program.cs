using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbUp;
using System.Reflection;

namespace DbUpLesson
{
  class Program
  {
    static void Main(string[] args)
    {
      var connectionStringConfiguration = ConfigurationManager.ConnectionStrings["AppConnection"];
      var connectionString = connectionStringConfiguration.ConnectionString;

      #region NewsMigration
      EnsureDatabase.For.SqlDatabase(connectionString);

      var upgrader = DeployChanges.To
     .SqlDatabase(connectionString)
     .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
     .LogToConsole()
     .Build();

      var result = upgrader.PerformUpgrade();

      if (!result.Successful) throw new Exception("NO NO NO NO NO");
      #endregion

      Menu menu = new Menu();
      menu.Choices();
    }
  }
}
