namespace SolutionShop.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Contents { get; set; }
        public string Name { get; set; }
    }
}