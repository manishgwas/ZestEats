namespace Restaurant.Domain
{
    public class SagaCompensation
    {
        public int RestaurantId { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
