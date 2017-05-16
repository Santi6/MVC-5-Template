using AutoMapper;

namespace SocialNetworkSystem.Web.Infastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression config);
    }
}