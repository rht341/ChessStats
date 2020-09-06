using System;
using unirest_net.http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChessStats
{
    class Program
    {
        private const string Url = "https://api.chess.com/pub/player/rht609/stats";

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Chess Stats!");

            HttpResponse<string> response = Unirest.get(Url)
                                                   .header("Accept", "application/json")
                                                   .asJson<string>();

            //Console.WriteLine(response.Body.ToString());
            
            dynamic stats = JObject.Parse(response.Body.ToString());

            string blitzRating = stats.chess_blitz.last.rating;
            Console.WriteLine(blitzRating);
        }
    }
}
