using MVVMFirma.Models.Entities;        // EF kontekst i encje
using MVVMFirma.Models.EntitiesForView; // UserPurchaseSummary
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVMFirma.Models.BussinesLogic
{
    public class UserPurchaseLogic
    {
        private readonly VoucherShopEntities db;

        public UserPurchaseLogic(VoucherShopEntities dbContext)
        {
            db = dbContext;
        }

        /// <summary>
        /// Zwraca listę (po jednym rekordzie na klienta)
        /// z sumą łącznej kwoty i liczbą zamówień (Orders) o statusie "Completed".
        /// </summary>
        public List<UserPurchaseSummary> GetUserPurchases(DateTime? dateFrom, DateTime? dateTo)
        {
            // 1. Zamówienia tylko Completed
            var ordersQuery = db.Orders
                .Where(o => o.Status == "Completed");

            // 2. Filtruj po datach (opcjonalnie)
            if (dateFrom.HasValue)
            {
                ordersQuery = ordersQuery.Where(o => o.OrderDate >= dateFrom.Value);
            }
            if (dateTo.HasValue)
            {
                ordersQuery = ordersQuery.Where(o => o.OrderDate <= dateTo.Value);
            }

            // 3. Grupowanie po kliencie
            //    Każda "paczka" = wszystkie zamówienia jednego klienta.
            var groupedOrders = ordersQuery
                .GroupBy(o => new
                {
                    o.CustomerID,
                    o.Customers.FirstName,
                    o.Customers.LastName
                });

            // 4. Wyciągamy sumy z grupy
            var result = groupedOrders
                .Select(g => new UserPurchaseSummary
                {
                    CustomerID = g.Key.CustomerID,
                    FullName = g.Key.FirstName + " " + g.Key.LastName,

                    // Liczba completed orders
                    PurchaseCount = g.Count(),

                    // Suma kwot z Orders.TotalPrice
                    TotalSpent = g.Sum(order => order.TotalPrice)
                })
                .ToList();

            return result;
        }
    }
}
