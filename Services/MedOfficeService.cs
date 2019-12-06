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
    public class MedOfficeService : IMedOfficeService
    {
        private readonly IMedOfficeRepository _medOfficeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public MedOfficeService(IMedOfficeRepository medOfficeRepository, IDepartmentRepository departmentRepository)
        {
            _medOfficeRepository = medOfficeRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task AddMedOffice(AddMedOfficeDto medOffice)
        {
            var tempMedOffice = await _medOfficeRepository.GetByOfficeNumberAndDepartmentId(medOffice.OfficeNumber, medOffice.DepartmentName);
            if (tempMedOffice != null)
                throw new Exception("This medOffice is existed id DB");

            var department = await _departmentRepository.GetByName(medOffice.DepartmentName);
            if (department == null)
                throw new Exception("Bad departmentId");

            var newMedOffice = new MedOffice();
            newMedOffice.Id = Guid.NewGuid();
            newMedOffice.Description = medOffice.Description;
            newMedOffice.Department =  department;
            newMedOffice.OfficeNumber = medOffice.OfficeNumber;


            await _medOfficeRepository.AddMedOffice(newMedOffice);
        }

        public async Task DeleteMedOffice(Guid id)
        {
            var tempMedOffice = await _medOfficeRepository.GetById(id);
            if (tempMedOffice == null)
                throw new Exception("Bad id");
            await _medOfficeRepository.DeleteMedOffice(tempMedOffice);
        }

        public async Task<IEnumerable<MedOfficeDto>> GetAll()
        {
            var offices = await _medOfficeRepository.Get();
            var newOffices = new List<MedOfficeDto>();
            foreach (var office in offices)
                newOffices.Add(office.mapToMedOfficeDto());
            
            return newOffices;
        }


        public async Task<MedOffice> GetById(Guid id)
            => await _medOfficeRepository.GetById(id);

        public async Task<IEnumerable<MedOffice>> GetByDepartment(Guid departmentId)
        {
            var department = await _departmentRepository.GetById(departmentId);
            if (department == null)
                throw new Exception("Bad departmentId");

            return await _medOfficeRepository.GetByDepartment(department);
        }

        public async Task UpdateMedOffice(MedOfficeDto medOffice)
        {
            var tempMedOffice = await _medOfficeRepository.GetById(medOffice.Id);
            if (tempMedOffice != null)
                throw new Exception("This medOffice is existed id DB");

            var department = _departmentRepository.GetById(medOffice.Department.Id);
            if (department == null)
                throw new Exception("Bad departmentId");

            tempMedOffice.Department = await department;
            tempMedOffice.Description = medOffice.Description;
            tempMedOffice.OfficeNumber = medOffice.OfficeNumber;
            await _medOfficeRepository.UpdateMedOffice(tempMedOffice);
 
        }
    }
}
