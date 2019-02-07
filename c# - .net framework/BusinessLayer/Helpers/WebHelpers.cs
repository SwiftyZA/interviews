using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helpers
{
    internal static class WebHelpers
    {
        private static string _webApiEndpoint = ConfigurationManager.AppSettings["WebApiEndpoint"];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        internal static async Task<string> ExecuteWebApiCall(string jsonString)
        {
            string result = string.Empty;
            using (var client = new HttpClient())
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_webApiEndpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }

            Assert.IsTrue(result.Length > 0, "Call the the Web Api returned a blank result");

            return result;
        }
    }
}
