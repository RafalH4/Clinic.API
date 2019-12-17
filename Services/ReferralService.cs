using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.DTOs.Mappers;
using Clinic.API.IRepositories;
using Clinic.API.IServices;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Services
{
    public class ReferralService : IReferralService
    {
        private readonly IReferralRepository _referralRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public ReferralService(
            IReferralRepository referralRepository,
            IAppointmentRepository appointmentRepository)
        {
            _referralRepository = referralRepository;
            _appointmentRepository = appointmentRepository;

        }
        public async Task AddReferral(AddReferralDto referralDto, Guid appointmentId)
        {
            var appointment = await _appointmentRepository.GetById(appointmentId);
            if (appointment == null)
                throw new Exception("Bad Appointment Id");

            var newReferral = referralDto.MapToReferral(appointment);

            await _referralRepository.AddReferral(newReferral);
        }

        public Task AddReferral()
        {
            throw new NotImplementedException();
        }

        public Task DeleteReferral()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Referral>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReferralDto>> GetByAppointmentId(Guid id)
        {
            var appointment = await _appointmentRepository.GetById(id);
            if (appointment == null)
                throw new Exception("bad appointment id");
            var referrals = await _referralRepository.GetByAppointment(appointment);
            var referralsDto = new List<ReferralDto>();
            foreach (var referral in referrals)
                referralsDto.Add(referral.MapToReferralDto());

            return referralsDto;
        }

        public Task<Referral> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Referral>> GetWithFilters()
        {
            throw new NotImplementedException();
        }

        public Task UpdateReferral()
        {
            throw new NotImplementedException();
        }
    }
}
