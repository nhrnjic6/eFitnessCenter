using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class UserStatusService
    {
        private readonly FitnessCenterDbContext _context;
        private readonly List<MembershipType> _membershipTypes;

        public UserStatusService(FitnessCenterDbContext context)
        {
            _context = context;
            _membershipTypes = _context.MembershipTypes.ToList();
        }

        public UserStatus CalculateUserStatus(AppUser user)
        {
            if(user.Status == UserStatus.DELETED)
            {
                return UserStatus.DELETED;
            }

            foreach(var payment in user.Client.MembershipPayments)
            {
                DateTime membershipExpiresAt = GetMembershipExpirationDate(payment);
                if(membershipExpiresAt > DateTime.Now)
                {
                    return UserStatus.ACTIVE;
                }
            }

            return UserStatus.INACTIVE;
        }

        private DateTime GetMembershipExpirationDate(MembershipPayment membershipPayment)
        {
            MembershipType membershipType = _membershipTypes
                .Where(x => x.Id == membershipPayment.MembershipTypeId)
                .FirstOrDefault();

            return membershipPayment.CreatedAt.AddMonths(membershipType.MonthsValid);
        }
    }
}
