using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Employees.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Template.Employees
{
    public class EmployeeAppService : AsyncCrudAppService<Employee, GetAllEmpDTO,int, GetEmpFilterDTO,CreateEmpDTO,CreateEmpDTO, EntityDto, DeleteEmpDTO>
    {
        
        private readonly IObjectMapper _objectMapper;
        public EmployeeAppService(IRepository<Employee,int> emprepository, IObjectMapper objectMapper)
            : base(emprepository)
        {
       
            _objectMapper = objectMapper;
        }


        public override async Task<GetAllEmpDTO> Update(CreateEmpDTO input)
        {
            CheckUpdatePermission();

            Employee entity = await GetEntityByIdAsync(input.Id);

            //value object mapping
            entity.Address = new Address(input.Address.FullAddress, input.Address.AppartmentNumber);

            MapToEntity(input, entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }
        public async Task<GetAllEmpDTO> PatchEmployee(int id, JsonPatchDocument<PatchEmpDTO> input)
        {
            if (input == null)
                throw new ArgumentNullException();
            Employee emp =  Repository.Get(id);
            if (emp == null)
                throw new NullReferenceException();

            PatchEmpDTO EmpToPatch = _objectMapper.Map<PatchEmpDTO>(emp);


            //validation logic here

            

            input.ApplyTo(EmpToPatch);
            Employee updatedEmp = _objectMapper.Map(EmpToPatch, emp);
            
            //value object mapping
            updatedEmp.Address = new Address(EmpToPatch.Address.FullAddress, EmpToPatch.Address.AppartmentNumber);

            Employee resultEmp = await Repository.UpdateAsync(updatedEmp);
            
            return  _objectMapper.Map<GetAllEmpDTO>(resultEmp);
        }
    }
  
}
