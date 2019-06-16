using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RS2_Seminarski.Database;
using RS2_Seminarski.Exceptions;
using RS2_Seminarski.Mappers;
using RS2_Seminarski.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Services
{
    public class SuplementPaymentService
    {
        private readonly IMapper _mapper;
        private readonly FitnessCenterDbContext _context;

        public SuplementPaymentService(FitnessCenterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Suplements.SuplementPayment> GetAll(
            Models.Requests.Suplements.SuplementPaymentSearchParams searchParams)
        {
            IQueryable<SuplementPayment> query = _context.SuplementPayments
                .Include(x => x.Employee)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.Client)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.Suplement)
                    .ThenInclude(x => x.SuplementType)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchParams.ClientFirstName))
            {
                query = query.Where(x => x.Client.AppUser.FirstName.StartsWith(searchParams.ClientFirstName));
            }

            if (!string.IsNullOrEmpty(searchParams.ClientLastName))
            {
                query = query.Where(x => x.Client.AppUser.LastName.StartsWith(searchParams.ClientLastName));
            }

            if (!string.IsNullOrEmpty(searchParams.SuplementName))
            {
                query = query.Where(x => x.Suplement.Name.StartsWith(searchParams.SuplementName));
            }

            if (!string.IsNullOrEmpty(searchParams.SuplementType))
            {
                query = query.Where(x => x.Suplement.SuplementType.Type == searchParams.SuplementType);
            }

            return query.Select(x => SuplementPaymentMapper.fromDb(x))
                .ToList();
        }

        public Models.Suplements.SuplementPayment GetById(int id)
        {
            SuplementPayment payment = _context.SuplementPayments
                .Include(x => x.Employee)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.Client)
                    .ThenInclude(x => x.AppUser)
                .Include(x => x.Suplement)
                    .ThenInclude(x => x.SuplementType)
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if(payment == null)
            {
                throw new ResourceNotFoundException($"Suplement payment with id: {id} not found");
            }

            return SuplementPaymentMapper.fromDb(payment);
        }

        public Models.Suplements.SuplementPayment Create(
            Models.Requests.Suplements.SuplementPaymentRequest paymentRequest, UserInfo info)
        {
            SuplementPayment dbPayment = SuplementPaymentMapper.toDb(paymentRequest, info);
            _context.SuplementPayments.Add(dbPayment);
            _context.SaveChanges();

            return GetById(dbPayment.Id);
        }

        public void Update(
            int id,
            Models.Requests.Suplements.SuplementPaymentRequest paymentRequest)
        {
            SuplementPayment payment = _context.SuplementPayments
            .Where(x => x.Id == id)
            .FirstOrDefault();

            if (payment == null)
            {
                throw new ResourceNotFoundException($"Suplement payment with id: {id} not found");
            }

            payment.SuplementId = paymentRequest.SuplementId;
            payment.ClientId = paymentRequest.ClientId;
            payment.Amount = paymentRequest.Amount;

            _context.SuplementPayments.Update(payment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            SuplementPayment payment = _context.SuplementPayments
            .Where(x => x.Id == id)
            .FirstOrDefault();

            if (payment == null)
            {
                throw new ResourceNotFoundException($"Suplement payment with id: {id} not found");
            }

            _context.SuplementPayments.Remove(payment);
            _context.SaveChanges();
        }
    }
}
