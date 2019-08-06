using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Template.MultiTenancy.Dto;

namespace Template.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

