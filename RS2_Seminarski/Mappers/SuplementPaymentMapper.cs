using Models.Requests.Suplements;
using Models.Suplements;
using RS2_Seminarski.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Mappers
{
    public class SuplementPaymentMapper
    {
        public static SuplementPayment fromDb(Database.SuplementPayment payment)
        {
            return new SuplementPayment
            {
                Amount = payment.Amount,
                CreatedAt = payment.CreatedAt.ToString("dd-MM-yyyy"),
                ClientName = $"{payment.Client.AppUser.FirstName} {payment.Client.AppUser.LastName}",
                SuplementName = payment.Suplement.Name,
                Id = payment.Id,
                EmployeeName = $"{payment.Employee.AppUser.FirstName} {payment.Employee.AppUser.LastName}",
                TotalPrice = payment.Suplement.Price * payment.Amount
            };
        }

        public static Database.SuplementPayment toDb(SuplementPaymentRequest paymentRequest, UserInfo info)
        {
            return new Database.SuplementPayment
            {
                Amount = paymentRequest.Amount,
                SuplementId = paymentRequest.SuplementId,
                EmployeeId = info?.Id,
                ClientId = paymentRequest.ClientId,
                CreatedAt = DateTime.Now
            };
        }
    }
}
