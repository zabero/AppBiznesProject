using System.Collections.Generic;
using System.Linq;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.Models.BussinesLogic
{
    public class PaymentLogic : DatabaseClass
    {
        public PaymentLogic(VoucherShopEntities db) : base(db) { }

        public List<FailedPayment> GetFailedPayments()
        {
            return db.Payments
                .Where(p => p.PaymentStatus == "Failed") // Filtruj nieudane płatności
                .Select(p => new FailedPayment
                {
                    PaymentID = p.PaymentID,
                    OrderID = p.OrderID,
                    PaymentAmount = p.PaymentAmount,
                    PaymentDate = p.PaymentDate,
                    PaymentMethod = p.PaymentMethod
                })
                .ToList();
        }
    }
}
