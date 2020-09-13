using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChessStats
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    class Program
    {
        private const string chessComUrl = "https://api.chess.com/pub/player/rht609/stats";
        private const string lichessUrl = "https://lichess.org/api/player/rht341";

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

            using (var client = new HttpClient())
            {
                // var result = await client.GetAsync(Url);
                // Console.WriteLine(result.StatusCode);

                // chess.com
                var content = await client.GetStringAsync(chessComUrl);
                // Console.WriteLine(content);

                dynamic stats = JObject.Parse(content);

                string blitzRating = stats.chess_blitz.last.rating;
                Console.WriteLine($"Rich's Chess.com blitz rating is {blitzRating}.");

                //lichess

                content = await client.GetStringAsync(lichessUrl);

                stats = JObject.Parse(content);
            }

        }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
