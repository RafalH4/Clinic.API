using Clinic.API.DTOs;
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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public PrescriptionService(
            IPrescriptionRepository prescriptionRepository,
            IAppointmentRepository appointmentRepository
            )
        {
            _prescriptionRepository = prescriptionRepository;
            _appointmentRepository = appointmentRepository;
        }
        public async Task AddPrescription(AddPrescriptionDto prescription, Guid appointmentId)
        {
            var appointment = await _appointmentRepository.GetById(appointmentId);
            if (appointment == null)
                throw new Exception("Bad Appointment Id");

            var newPrescription = prescription.MapToPrescription(appointment);

            await _prescriptionRepository.AddPrescription(newPrescription);
        }

        public Task DeletePrescription()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prescription>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Prescription> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Prescription>> GetWithFilters()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePrescription()
        {
            throw new NotImplementedException();
        }
    }
}
