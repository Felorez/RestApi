namespace RestApi.Models
{
    public class UserModel
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public string? City { get; set; }
        public int? Age { get; set; }
    }
}
