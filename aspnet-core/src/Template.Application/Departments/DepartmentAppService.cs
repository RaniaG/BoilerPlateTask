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
using Template.Employees.DTOs;

namespace Template.Departments
{
    public class DepartmentAppService : AsyncCrudAppService<Department, GetAllDeptDTO,int,GetAllDeptsInputDTO,CreateDeptDTO>
    {
        IDepartmentDomainService deptDomainService;
        private readonly IObjectMapper _objectMapper;

        public DepartmentAppService(IRepository<Department, int> repository,
        IDepartmentDomainService deptDomainService,IObjectMapper objectMapper
            ) : base(repository)
        {
            this.deptDomainService = deptDomainService;
            _objectMapper = objectMapper;
        }
        //public override async Task<GetAllDeptDTO> Get(EntityDto<int> input)
        //{
        //    CheckGetPermission();
        //    //eager loading 
        //    Department entity = Repository.GetAllIncluding(d => d.Manager).First(d => d.Id == input.Id);
        //    return MapToEntityDto(entity);
        //}

        protected override IQueryable<Department> CreateFilteredQuery(GetAllDeptsInputDTO input)
        {
            return Repository.GetAllIncluding(d=>d.Manager);
        }
        
        public  List<GetAllEmpDTO> GetEmployees(EntityDto<int> input)
        {
            return deptDomainService.GetEmployees(input.Id)
            .Select(e => _objectMapper.Map<GetAllEmpDTO>(e)).ToList();
        }
    }
}
