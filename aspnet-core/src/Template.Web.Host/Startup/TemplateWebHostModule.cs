using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Template.Configuration;
using Abp.Zero.Configuration;
using Abp.MultiTenancy;

namespace Template.Web.Host.Startup
{
    [DependsOn(
       typeof(TemplateWebCoreModule))]
    public class TemplateWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TemplateWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            Configuration.MultiTenancy.IsEnabled = false;
            Configuration.MultiTenancy.IgnoreFeatureCheckForHostUsers = true;

        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TemplateWebHostModule).GetAssembly());
        }
    }
}
