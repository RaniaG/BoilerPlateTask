using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;

using Template.Employees.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Abp.ObjectMapping;

using System.Linq;
using Template.Departments;
using Abp.Extensions;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Template.Employees
{
    public class EmployeeAppService : AsyncCrudAppService<Employee, GetAllEmpDTO,int, GetEmpFilterDTO,CreateEmpDTO,CreateEmpDTO, EntityDto, DeleteEmpDTO>
    {
        
        private readonly IObjectMapper _objectMapper;
        private readonly IDepartmentDomainService deptDomainService;

        public EmployeeAppService(IRepository<Employee,int> emprepository,
            IDepartmentDomainService deptDomainService
            , IObjectMapper objectMapper)
            : base(emprepository)
        {
       
            _objectMapper = objectMapper;
            this.deptDomainService = deptDomainService;
        }
       
        protected override IQueryable<Employee> ApplyPaging(IQueryable<Employee> query, GetEmpFilterDTO input)
        {
            if (input.SkipCount != 0)
                query = query.Skip(input.SkipCount);
            if (input.MaxResultCount > 0)
                query = query.Take(input.MaxResultCount);
            return query;

            //Try to use paging if available
            //var pagedInput = input as IPagedResultRequest;
            //if (pagedInput != null)
            //{

            //    return query.PageBy(pagedInput);
            //}

            ////Try to limit query result if available
            //var limitedInput = input as ILimitedResultRequest;
            //if (limitedInput != null)
            //{
            //    return query.Take(limitedInput.MaxResultCount);
            //}

            ////No paging
            //return query;
        }
        protected override IQueryable<Employee> ApplySorting(IQueryable<Employee> query, GetEmpFilterDTO input)
        {
            //Try to sort query if available
            //var sortInput = input as ISortedResultRequest;

            if (input != null)
            {
                if (!input.Sorting.IsNullOrWhiteSpace())
                {
                    StringBuilder sortQuery = new StringBuilder(input.Sorting);
                    if (input.SortingDirection == SortDirection.desc)
                        sortQuery.Append(" descending");

                    
                        return query.OrderBy(sortQuery.ToString());

                }
            }

            //IQueryable.Task requires sorting, so we should sort if Take will be used.
            if (input is ILimitedResultRequest)
            {
                return query.OrderByDescending(e => e.Id);
            }

            //No sorting
            return query;
        }
        protected override IQueryable<Employee> CreateFilteredQuery(GetEmpFilterDTO input)
        {
            IQueryable<Employee> emps = Repository.GetAll();
                //.WhereIf(string.IsNullOrEmpty(input.Name), e => e.Name.ToLower().Contains(input.Name.ToLower()));
            if (!string.IsNullOrEmpty(input.Name))
                emps = emps.Where(e => e.Name.ToLower().Contains( input.Name.ToLower()));
            if (input.DepartmentId != null)
                emps = emps.Where(e => e.DepartmentId == input.DepartmentId);
            return emps;
        }
        public override async Task<GetAllEmpDTO> Update(CreateEmpDTO input)
        {
            if (input.DepartmentId!=null&&!deptDomainService.DepartmentExists((int)input.DepartmentId))
                throw new ArgumentException(); 
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
