using System;
using System.Data.SqlClient;
using PaymentService.Domain;
using System.Collections.Generic;

namespace PaymentService.Persistence
{
    public class SqlPaymentRepository : IPaymentRepository
    {
        private readonly string _connectionString;
        public SqlPaymentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Payment CreatePayment(Payment payment)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Payments (Id, OrderId, Status, CreatedAt, RazorpayPaymentId, IdempotencyKey) VALUES (@Id, @OrderId, @Status, @CreatedAt, @RazorpayPaymentId, @IdempotencyKey)", conn);
            cmd.Parameters.AddWithValue("@Id", payment.Id);
            cmd.Parameters.AddWithValue("@OrderId", payment.OrderId);
            cmd.Parameters.AddWithValue("@Status", payment.Status);
            cmd.Parameters.AddWithValue("@CreatedAt", payment.CreatedAt);
            cmd.Parameters.AddWithValue("@RazorpayPaymentId", (object?)payment.RazorpayPaymentId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IdempotencyKey", (object?)payment.IdempotencyKey ?? DBNull.Value);
            cmd.ExecuteNonQuery();
            return payment;
        }

        public Payment? GetPaymentByOrderId(string orderId)
        {
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            var cmd = new SqlCommand("SELECT TOP 1 * FROM Payments WHERE OrderId = @OrderId", conn);
            cmd.Parameters.AddWithValue("@OrderId", orderId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Payment
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    OrderId = reader.GetString(reader.GetOrdinal("OrderId")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                    RazorpayPaymentId = reader["RazorpayPaymentId"] as string,
                    IdempotencyKey = reader["IdempotencyKey"] as string
                };
            }
            return null;
        }

        public async Task<int> CleanupStalePaymentsAsync()
        {
            // Remove payments older than 1 day and not completed
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();
            var cmd = new SqlCommand("DELETE FROM Payments WHERE Status != 'COMPLETED' AND CreatedAt < @Cutoff", conn);
            cmd.Parameters.AddWithValue("@Cutoff", DateTime.UtcNow.AddDays(-1));
            int rows = await cmd.ExecuteNonQueryAsync();
            return rows;
        }
    }
}
