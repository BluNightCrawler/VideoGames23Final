namespace VideoGames23.Models
{
    public class IGameRepo
    {
        IQueryable<Product> Products { get; }
    }
}
