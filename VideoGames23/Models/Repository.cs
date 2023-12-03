using System.Collections.Generic;
namespace VideoGames23.Models
{
    public class Repository
    {
        private static List<Product> responses = new List<Product>();
        public static IEnumerable<Product> Response => responses;

        public static void AddResponse(Product response)
        {
            responses.Add(response);
        }
    }
}
