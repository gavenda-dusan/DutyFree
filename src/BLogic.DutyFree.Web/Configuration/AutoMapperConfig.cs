using Autofac;
using AutoMapper;
using System.Collections.Generic;

namespace DutyFree.Web.Configuration
{
    public static class AutoMapperConfig
    {
        public static IMapper Configure(IComponentContext context)
        {
            return new MapperConfiguration(cfg =>
                {
                    foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                    {
                        cfg.AddProfile(profile);
                    }
                }
            ).CreateMapper();
        }
    }
}