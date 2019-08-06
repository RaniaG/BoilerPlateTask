using Abp.Modules;
using Abp.MultiTenancy;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Template.Authorization.Roles;
using Template.Authorization.Users;
using Template.Configuration;
using Template.Localization;
using Template.MultiTenancy;
using Template.Timing;

namespace Template
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class TemplateCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            TemplateLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = TemplateConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            //////////////adding a new role???
            Configuration.Modules.Zero().RoleManagement.StaticRoles.Add(new StaticRoleDefinition("Employee", MultiTenancySides.Tenant));

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TemplateCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
