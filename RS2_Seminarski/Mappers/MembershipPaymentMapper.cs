using Models.Clients;
using Models.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Mappers
{
    public class MembershipPaymentMapper
    {
        public static MembershipPayment FromDb(Database.MembershipPayment membershipPayment)
        {
            Client client = new Client
            {
                Id = (int)membershipPayment.ClientId,
                FirstName = membershipPayment.Client.AppUser.FirstName,
                LastName = membershipPayment.Client.AppUser.LastName
            };

            MembershipType membershipType = new MembershipType
            {
                Id = (int)membershipPayment.MembershipTypeId,
                MonthsValid = membershipPayment.MembershipType.MonthsValid,
                Name = membershipPayment.MembershipType.Name,
                Price = membershipPayment.MembershipType.Price
            };

            return new MembershipPayment
            {
                Id = membershipPayment.Id,
                CreatedAt = membershipPayment.CreatedAt.ToString("dd-MM-yyyy"),
                ClientId = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MembershipTypeName = membershipType.Name,
                ValidDescriptor = "Valid or Invalid",
                TotalPaid = membershipType.Price
            };
        }
    }
}
