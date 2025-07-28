using System.Collections.Generic;
using PaymentService.Domain;

namespace PaymentService.Domain
{
    public class ManualReconciliationService
    {
        private readonly List<Payment> _auditLog = new();
        public void LogPayment(Payment payment) => _auditLog.Add(payment);
        public IEnumerable<Payment> GetAuditLog() => _auditLog;
        public void MarkAsReconciled(Payment payment) => payment.Status = "Reconciled";
    }
}
