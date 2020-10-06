using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ChessStats
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    class Program
    {
        private const string chessComUrl = "https://api.chess.com/pub/player/rht609/stats";
        private const string lichessUrl = "https://lichess.org/api/account";

          static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello Chess Stats!");

 /*            HttpResponse<string> response = Unirest.get(Url)
                                                   .header("Accept", "application/json")
                                                   .asJson<string>();

            //Console.WriteLine(response.Body.ToString());
            
            dynamic stats = JObject.Parse(response.Body.ToString());

            string blitzRating = stats.chess_blitz.last.rating;
            Console.WriteLine(blitzRating); */

        //     using (var client = new HttpClient())
        //     {
        //         // var result = await client.GetAsync(Url);
        //         // Console.WriteLine(result.StatusCode);

        //         // chess.com
        //         var content = await client.GetStringAsync(chessComUrl);
        //         // Console.WriteLine(content);

        //         dynamic stats = JObject.Parse(content);

        //         string blitzRating = stats.chess_blitz.last.rating;
        //         Console.Write($"Rich's Chess.com blitz rating is {blitzRating}, ");

        //         //lichess

        //         //content = await client.GetStringAsync(lichessUrl);

        //         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "AvVVbU6yICi9FKvs");
        //         content = await client.GetStringAsync(lichessUrl);
        //         stats = JObject.Parse(content);
        //         blitzRating = stats.perfs.blitz.rating;
        //         Console.WriteLine($"lichess blitz rating is {blitzRating}.");
        //     }

            RestClient client = new RestClient(chessComUrl);

            RestRequest request = new RestRequest(RestSharp.Method.GET);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddHeader("Content-Type", "applicaton/json");

            IRestResponse response = await client.ExecuteAsync(request);

            // string content = response.Content.Substring(9, response.Content.Length-17);
            string content = response.Content;

            dynamic result = JObject.Parse(content);

            string blitzRating = result.chess_blitz.last.rating;

            Console.Write($"Rich's Chess.com blitz rating is {blitzRating}, ");

            client = new RestClient(lichessUrl);
            request.AddHeader("Authorization", "Bearer AvVVbU6yICi9FKvs");

            response = await client.ExecuteAsync(request);
            content = response.Content;

            result = JObject.Parse(content);
            blitzRating = result.perfs.blitz.rating;

            Console.WriteLine($"lichess blitz rating is {blitzRating}.");
        }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
