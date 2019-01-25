using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureLetsEncryptRenewerScheduler
{
    public static class WebJobCaller
    {
        [FunctionName("WebJobCaller")]
        public static async Task RunAsync([TimerTrigger("0 12 4 1 */1 *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string webJobUser = Environment.GetEnvironmentVariable("WebJobUser");

            string webJobPw = Environment.GetEnvironmentVariable("WebJobPassword");

            HttpClient httpClient = new HttpClient();

            string leRenewerAppName = Environment.GetEnvironmentVariable("LetsEncryptRenewerWebApp");

            string webhookAddress = $"https://{leRenewerAppName}.scm.azurewebsites.net/api/triggeredwebjobs/ssl-renewer/run";

            var request = new HttpRequestMessage(HttpMethod.Post, webhookAddress);
            var byteArray = Encoding.ASCII.GetBytes($"{webJobUser}:{webJobPw}");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                //Alert
            }
        }
    }
}
