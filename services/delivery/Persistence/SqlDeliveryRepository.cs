using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DeliveryService.Domain;

namespace DeliveryService.Persistence
{
    public class SqlDeliveryRepository : IDeliveryRepository
    {
        private readonly string _connectionString;
        public SqlDeliveryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Delivery> CreateAsync(Delivery delivery)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("INSERT INTO Deliveries (Id, OrderId, Address, Status, AssignedAt, DeliveredAt, CourierId, IdempotencyKey) VALUES (@Id, @OrderId, @Address, @Status, @AssignedAt, @DeliveredAt, @CourierId, @IdempotencyKey)", conn);
            cmd.Parameters.AddWithValue("@Id", delivery.Id);
            cmd.Parameters.AddWithValue("@OrderId", delivery.OrderId);
            cmd.Parameters.AddWithValue("@Address", delivery.Address);
            cmd.Parameters.AddWithValue("@Status", delivery.Status);
            cmd.Parameters.AddWithValue("@AssignedAt", delivery.AssignedAt);
            cmd.Parameters.AddWithValue("@DeliveredAt", (object?)delivery.DeliveredAt ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CourierId", (object?)delivery.CourierId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IdempotencyKey", (object?)delivery.IdempotencyKey ?? DBNull.Value);
            await cmd.ExecuteNonQueryAsync();
            return delivery;
        }

        public async Task<Delivery?> GetByIdAsync(Guid id)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("SELECT * FROM Deliveries WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Delivery
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    OrderId = reader.GetString(reader.GetOrdinal("OrderId")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    AssignedAt = reader.GetDateTime(reader.GetOrdinal("AssignedAt")),
                    DeliveredAt = reader["DeliveredAt"] as DateTime?,
                    CourierId = reader["CourierId"] as string,
                    IdempotencyKey = reader["IdempotencyKey"] as string
                };
            }
            return null;
        }

        public async Task UpdateStatusAsync(Guid id, string status)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("UPDATE Deliveries SET Status = @Status WHERE Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Id", id);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Delivery>> GetStaleDeliveriesAsync()
        {
            var result = new List<Delivery>();
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("SELECT * FROM Deliveries WHERE Status != 'DELIVERED' AND AssignedAt < @Cutoff", conn);
            cmd.Parameters.AddWithValue("@Cutoff", DateTime.UtcNow.AddHours(-2));
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new Delivery
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    OrderId = reader.GetString(reader.GetOrdinal("OrderId")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    AssignedAt = reader.GetDateTime(reader.GetOrdinal("AssignedAt")),
                    DeliveredAt = reader["DeliveredAt"] as DateTime?,
                    CourierId = reader["CourierId"] as string,
                    IdempotencyKey = reader["IdempotencyKey"] as string
                });
            }
            return result;
        }
    }
}
