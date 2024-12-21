using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.BussinesLogic
{
    public class VoucherProfit:DatabaseClass
    {
        public VoucherProfit(VoucherShopEntities db):base (db){}

        public decimal? ProfitByDate(int voucherID, DateTime dateFrom, DateTime dateTo)
        {
            return db.OrderItems
                .Join(db.Vouchers, oi => oi.VoucherID, v => v.VoucherID, (oi, v) => new { oi, v })
                .Join(db.Orders, ov => ov.oi.OrderID, o => o.OrderID, (ov, o) => new { ov.oi, ov.v, o })
                .Where(x =>
                    x.v.VoucherID == voucherID && // Filtruj po ID produktu (voucheru)
                    x.o.OrderDate >= dateFrom && // Zamówienia od daty początkowej
                    x.o.OrderDate <= dateTo) // Zamówienia do daty końcowej
                .Select(x => x.oi.Quantity * x.oi.Price) // Oblicz wartość (ilość * cena)
                .DefaultIfEmpty(0) // Obsługa przypadku braku wyników
                .Sum(); // Sumuj wartości
        }

    }
}
