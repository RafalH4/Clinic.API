﻿using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.DTOs.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentDto mapToDepartmentDto(this Department department)
        {
            var newDepartment = new DepartmentDto();
            newDepartment.Id = department.Id;
            newDepartment.Name = department.Name;
            newDepartment.PhoneNumber = department.PhoneNumber;
            newDepartment.Descriptcion = department.Descriptcion;
 
            return newDepartment;
        }

    }
}
