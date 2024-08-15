using System.Diagnostics;

namespace WebAppAsyncTaskConsole
{
    internal class Program
    {
         static async Task Main(string[] args)
        {

            do
            {
                Addlog("App is running..");
                Console.Write("Request Type (Sync : 0, Async : 1)   ");
                int requestType = int.Parse(Console.ReadLine());
                Console.Write("How many request:    ");
                int requestCount = int.Parse(Console.ReadLine());

                var sw = Stopwatch.StartNew();

                //var webApiClient = new WebApiClient();

                var tasks = requestType == 0 ? GetSyncTasks(requestCount) : GetAsyncTasks(requestCount);
                //await tasks;
                await Task.WhenAll(tasks);

                sw.Stop();
                Addlog($"Total time for {requestType} : {sw.ElapsedMilliseconds} ms");
                Addlog($"Total thread of hardware(processor): {Environment.ProcessorCount}");

            } while (Console.ReadKey().Key== ConsoleKey.R);
        }

        public static IEnumerable<Task> GetSyncTasks(int howMany)
        {
            var result = new List<Task>();
            WebApiClient client = new WebApiClient();

            for (int i = 0; i < howMany; i++)
                result.Add(client.CallSync());
                
            return result;
        }

        public static IEnumerable<Task> GetAsyncTasks(int howMany)
        {
            var result = new List<Task>();
            WebApiClient client = new WebApiClient();

            for (int i = 0; i < howMany; i++)
                result.Add(client.CallAsync());

            return result;
        }


        private static readonly string LogFilePath = "C:\\Users\\User\\Desktop\\dev\\aspnetcore\\WebAppAsyncTaskConsole/log.txt"; // Specify the path to your log file

        private static void Addlog(string logStr)
        {
            logStr = $"[{DateTime.UtcNow:dd.MM.yyyy HH:mm:ss}] - {logStr}";
            Console.WriteLine(logStr);
            // Log to the text file
            try
            {
                // Append the log entry to the file
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine(logStr);
                }
                Console.WriteLine("logged to file!");

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file access issues) here
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
