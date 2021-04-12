using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            Console.WriteLine("Log do console function 2");
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}, trying github actions CD");
        }
    }
}
