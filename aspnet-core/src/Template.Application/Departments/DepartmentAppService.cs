using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Departments.DTOs;
using Template.Employees;
using Template.Employees.DTOs;

namespace Template.Departments
{
    public class DepartmentAppService : AsyncCrudAppService<Department, GetAllDeptDTO,int,GetAllDeptsInputDTO,CreateDeptDTO>
    {
        private readonly IDepartmentDomainService deptDomainService;
        private readonly IEmployeeDomainService empDomainService;

        private readonly IObjectMapper _objectMapper;

        public DepartmentAppService(IRepository<Department, int> repository,
        IDepartmentDomainService deptDomainService,
            IEmployeeDomainService empDomainService
            , IObjectMapper objectMapper
            ) : base(repository)
        {
            this.deptDomainService = deptDomainService;
            _objectMapper = objectMapper;
            this.empDomainService = empDomainService;
        }
        public override async Task<GetAllDeptDTO> Get(EntityDto<int> input)
        {
            CheckGetPermission();
            //eager loading 
            Department entity = Repository.GetAllIncluding(d => d.Manager).First(d => d.Id == input.Id);
            return MapToEntityDto(entity);
        }

        protected override IQueryable<Department> CreateFilteredQuery(GetAllDeptsInputDTO input)
        {
            IQueryable<Department> depts= Repository.GetAllIncluding(d=>d.Manager);
            if (!string.IsNullOrEmpty(input.Name))
                depts = depts.Where(d => d.Name.ToLower().Contains( input.Name.ToLower()));
            if(input.ManagerId!=null)
                depts = depts.Where(d => d.ManagerId == input.ManagerId);
            return depts;
        }

        public  List<GetAllEmpDTO> GetEmployees(EntityDto<int> input)
        {
            return deptDomainService.GetEmployees(input.Id)
            .Select(e => _objectMapper.Map<GetAllEmpDTO>(e)).ToList();
        }
        public override Task Delete(EntityDto<int> input)
        {
             return deptDomainService.DeleteDepartment(input.Id);
        }
        public override Task<GetAllDeptDTO> Update(CreateDeptDTO input)
        {
            if(empDomainService.EmployeeExists(input.ManagerId))
                return base.Update(input);
            throw new ArgumentException();
        }
        public override Task<GetAllDeptDTO> Create(CreateDeptDTO input)
        {
            if (empDomainService.EmployeeExists(input.ManagerId))
                return base.Create(input);
            throw new ArgumentException();

        }


    }
}
