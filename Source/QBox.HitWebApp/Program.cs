using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QBox.HitWebApp
{
    class Program
    {
        static decimal prodCount = 0;
        static decimal stagCount = 0;

        static void Main(string[] args)
        {
            while (1 == 1)
                GetWebContent();
        }



        private static void GetWebContent()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(new Uri("https://quizbox-test.azurewebsites.net"));
            var html = response.Result.Content.ReadAsStringAsync().Result;
            if (html.Contains("2.0.9.0"))
                prodCount++;
            else if (html.Contains("2.0.10.0"))
                stagCount++;

            decimal percentage = 0;
            if (prodCount != 0 && stagCount != 0)
                percentage = (stagCount / prodCount) * 100;
            else
                percentage = 100;

            Console.Clear();
            Console.WriteLine("Prod hit {0} times, Staging hit {1} times, Percentage: {2}%", prodCount, stagCount, percentage.ToString("0.00"));
        }
    }
}
