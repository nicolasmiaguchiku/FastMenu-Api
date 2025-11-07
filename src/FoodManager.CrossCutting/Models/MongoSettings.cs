namespace FoodManager.CrossCutting.Models
{
    public sealed record MongoSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
    }
}
