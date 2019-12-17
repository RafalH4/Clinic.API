﻿using Clinic.API.DTOs;
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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        public PrescriptionService(
            IPrescriptionRepository prescriptionRepository,
            IAppointmentRepository appointmentRepository,
            IPatientRepository patientRepository
            )
        {
            _prescriptionRepository = prescriptionRepository;
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
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

        public async Task<IEnumerable<PrescriptionDto>> GetByAppointmentId(Guid id)
        {
            var appointment = await _appointmentRepository.GetById(id);
            if (appointment == null)
                throw new Exception("bad appointment id");
            var prescriptions = await _prescriptionRepository.GetByAppointment(appointment);
            var prescriptionsDto = new List<PrescriptionDto>();
            foreach (var prescription in prescriptions)
                prescriptionsDto.Add(prescription.MapToPrescriptionDto());
            
            return prescriptionsDto;

        }

        public async Task<Prescription> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PrescriptionDto>> GetByPatientId(Guid patientId)
        {
            var user = await _patientRepository.GetById(patientId);
            if (user == null)
                throw new Exception("Bad user id");

            var prescriptions = await _prescriptionRepository.GetByPatient(user);
            var prescriptionsDto = new List<PrescriptionDto>();
            foreach (var prescription in prescriptions)
                prescriptionsDto.Add(prescription.MapToPrescriptionDto());

            return prescriptionsDto;
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
