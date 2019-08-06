using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Membership;
using Models.Requests.Membership;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Mappers;
using RS2_Seminarski.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class MembershipPaymentService
    {
        private readonly IMapper _mapper;
        private readonly Database.FitnessCenterDbContext _context;

        public MembershipPaymentService(Database.FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MembershipPayment> GetAll(MembershipPaymentSearchParams searchParams, UserInfo userInfo)
        {
            IQueryable<Database.MembershipPayment> query = _context.MembershipPayments
                .AsQueryable()
                .Include(x => x.Client)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.MembershipType);

            if(userInfo.Role.Equals("EMPLOYEE") && searchParams.ClientId != null) 
            {
                query = query.Where(x => x.ClientId == searchParams.ClientId);
            }

            if(userInfo.Role.Equals("CLIENT"))
            {
                query = query.Where(x => x.ClientId == userInfo.Id);
            }

            return query
                .Select(x => MembershipPaymentMapper.FromDb(x))
                .ToList();
        }

        public MembershipPayment Create(
            MembershipPaymentCreate membershipPaymentCreate, int employeeId)
        {
            Database.MembershipPayment activePayment = _context.MembershipPayments
                .Include(x => x.MembershipType)
                .Where(x => x.ClientId == membershipPaymentCreate.ClientId)
                .Where(x => x.CreatedAt.AddMonths(x.MembershipType.MonthsValid) > DateTime.Now)
                .FirstOrDefault();

            if(activePayment != null)
            {
                throw new ActiveMembershipException();
            }

            Database.MembershipPayment membershipPayment = new Database.MembershipPayment
            {
                ClientId = membershipPaymentCreate.ClientId,
                EmployeeId = employeeId,
                MembershipTypeId = membershipPaymentCreate.MembershipTypeId,
                CreatedAt = DateTime.Now,
            };

            _context.MembershipPayments.Add(membershipPayment);
            _context.SaveChanges();

            Database.MembershipPayment createdPayment = _context.MembershipPayments
                .Include(x => x.Client)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.MembershipType)
                .FirstOrDefault(x => x.Id == membershipPayment.Id);

            return MembershipPaymentMapper.FromDb(createdPayment);
        }

        public void Update(int id ,MembershipPaymentUpdate membershipPaymentUpdate)
        {
            Database.MembershipPayment payment = _context.MembershipPayments.Find(id);
            if(payment == null)
            {
                throw new ResourceNotFoundException("Not found");
            }

            payment.MembershipTypeId = membershipPaymentUpdate.MembershipTypeId;
            _context.MembershipPayments.Update(payment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Database.MembershipPayment payment = _context.MembershipPayments.Find(id);
            if (payment == null)
            {
                throw new ResourceNotFoundException("Not found");
            }

            _context.MembershipPayments.Remove(payment);
            _context.SaveChanges();
        }
    }
}
