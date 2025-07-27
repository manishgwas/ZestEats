namespace Restaurant.Domain
{
    public class IdempotencyKey
    {
        public string Key { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
