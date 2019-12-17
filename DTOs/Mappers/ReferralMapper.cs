using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class ReferralMapper
    {
        public static Referral MapToReferral(this AddReferralDto referralDto, Appointment appointment)
        {
            var referral = new Referral();
            referral.CreatedAt = DateTime.Now;
            referral.Treatment = referralDto.Treatment;
            if (appointment != null)
                referral.Appointment = appointment;
            return referral;

        }

        public static ReferralDto MapToReferralDto(this Referral referral)
        {
            var referralDto = new ReferralDto();
            var appointment = referral.Appointment.mapToAppointmentDto();
            if (appointment == null)
                throw new Exception("Appointment cant be null");
            referralDto.Appointment = appointment;
            referralDto.CreatedAt = referral.CreatedAt;
            referralDto.Treatment = referral.Treatment;
            referralDto.Id = referral.Id;

            return referralDto;

        }
    }
}
