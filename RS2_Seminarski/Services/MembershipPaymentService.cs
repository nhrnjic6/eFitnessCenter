using AutoMapper;
using Models.Requests;
using RS2_Seminarski.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class MembershipPaymentService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;

        public MembershipPaymentService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.MembershipPayments.MembershipPayment> GetAll()
        {
            List<Database.MembershipPayment> membershipPayments = 
                _context.MembershipPayments.ToList();

            return membershipPayments
                .Select(x => _mapper.Map<Models.MembershipPayments.MembershipPayment>(x))
                .ToList();
        }

        public Models.MembershipPayments.MembershipPayment Create(
            MembershipPaymentCreate membershipPaymentCreate, int employeeId)
        {
            Database.MembershipPayment membershipPayment = new Database.MembershipPayment
            {
                ClientId = membershipPaymentCreate.ClientId,
                EmployeeId = employeeId,
                MembershipTypeId = membershipPaymentCreate.MembershipTypeId,
                CreatedAt = DateTime.Now,
            };

            _context.MembershipPayments.Add(membershipPayment);
            _context.SaveChanges();

            return _mapper.Map<Models.MembershipPayments.MembershipPayment>(membershipPayment);
        }
    }
}
