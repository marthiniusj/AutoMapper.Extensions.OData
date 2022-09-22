using DAL.EFCore;
using Domain.OData;
using System.Linq;

namespace WebAPI.OData.EFCore.Mappings
{
    public class CoreBuildingMappings : AutoMapper.Profile
    {
        public CoreBuildingMappings()
        {
            CreateMap<TBuilding, CoreBuilding>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.LongName))
                .ForMember(d => d.Tenant, o => o.MapFrom(s => s.Mandator))
                .ForAllMembers(o => o.ExplicitExpansion());

            int builderId = 0;

            CreateMap<TBuilder, OpsBuilder>()
                .ForAllMembers(o => o.ExplicitExpansion());
            CreateMap<TCity, OpsCity>()
                .ForMember(d => d.Builders, o => o.MapFrom(s => builderId == 0 ? s.Builders : s.Builders.Where(_ => _.Id == builderId)))
                .ForAllMembers(o => o.ExplicitExpansion());
        }
    }
}
