namespace SolutionShop.Data.Entities
{
    public class ForgotPassword
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}