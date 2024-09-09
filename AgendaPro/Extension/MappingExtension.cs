using AutoMapper;
using AgendaPro.Application.Mapping;

namespace AgendaPro.Web.Extension
{
    public static class MappingExtension
    {
        public static IServiceCollection AddMapping(
            this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ResquestProfile());
                mc.AddProfile(new ResponseProfile());
                mc.AddProfile(new ServiceProfile());

                //mc.ForAllMaps((obj, cnfg) => cnfg.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)));
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            return services;
        }
    }
}
