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

namespace Template.Employees
{
    public class EmployeeAppService : AsyncCrudAppService<Employee, GetAllEmpDTO,int, GetEmpFilterDTO,CreateEmpDTO,CreateEmpDTO, EntityDto, DeleteEmpDTO>
    {
        IRepository<Employee, int> _emprepository;
        private readonly IObjectMapper _objectMapper;
        public EmployeeAppService(IRepository<Employee,int> emprepository, IObjectMapper objectMapper)
            : base(emprepository)
        {
            _emprepository = emprepository;
            _objectMapper = objectMapper;
        }

        public override async Task<GetAllEmpDTO> Create(CreateEmpDTO input)
        {
            CheckCreatePermission();
            Employee entity = MapToEntity(input);
            
            await _emprepository.InsertAsync(entity);
            await CurrentUnitOfWork.SaveChangesAsync();

            return MapToEntityDto(entity);
        }

        public async Task<GetAllEmpDTO> PatchEmployee(int id, JsonPatchDocument<PatchEmpDTO> input)
        {
            if (input == null)
                throw new ArgumentNullException();
            Employee emp =  _emprepository.Get(id);
            if (emp == null)
                throw new NullReferenceException();

            PatchEmpDTO EmpToPatch = new PatchEmpDTO()
            {
                Name = emp.Name,
                Salary = emp.Salary,
                Title = emp.Title
            };
            
            //validation logic here
            input.ApplyTo(EmpToPatch);
            Employee emp2 = _objectMapper.Map(EmpToPatch, emp);
            Employee updatedEmp = await _emprepository.UpdateAsync(emp2);
            
            return  _objectMapper.Map<GetAllEmpDTO>(updatedEmp);
        }
    }
  
}
