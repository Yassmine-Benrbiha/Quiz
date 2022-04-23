using DbUp;

namespace DbUpMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"DBup migration Started at {DateTime.Now}");
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=myDatabase;Trusted_Connection=True";

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsFromFileSystem(@"../../../../projects/MyProject/Backend/Data/Scripts/")
                    .LogToConsole()
                    .Build();
            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.WriteLine($"DBup migration ended at {DateTime.Now}");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}