namespace GameStore.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Developer { get; set; } = null!;

        public double Price { get; set; }
    }
}
