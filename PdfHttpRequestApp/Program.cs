using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PdfHttpRequestApp
{
    /// <summary>
    /// This attempts to create HttpRequest with pdf payload to exercise a function running in the cloud.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Specify file name and uri");
            }

            var fileName = args[0];
            byte[] bytes = File.ReadAllBytes(fileName);

            var uri = args[1];

            //Never used httpclient before. I have no idea what i'm doing...
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/pdf"));//ACCEPT header


            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, uri);
            req.Content = new ByteArrayContent(bytes);
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //This would be for the example azure function.
            //req.Content = new StringContent("{\"name\":\"John Doe\"}",
            //                        Encoding.UTF8,
            //                        "application/json");//CONTENT-TYPE header

            SendAndReceive(client, req);
            

            Console.ReadLine();
        }

        private static async void SendAndReceive(HttpClient client, HttpRequestMessage req)
        {
            Console.WriteLine("SendAsync: {0}", req);
            var response = await client.SendAsync(req);
            Console.WriteLine("Response Status: {0}", response.StatusCode);
            Console.WriteLine("Response Content: {0}", response.Content);
            Console.WriteLine("Response: {0}", response.Headers);
            var contentStr = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Content string: {0}", contentStr);
        }
    }
}

