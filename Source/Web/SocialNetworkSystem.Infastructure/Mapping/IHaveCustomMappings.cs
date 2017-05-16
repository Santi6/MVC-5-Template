using AutoMapper;

namespace SocialNetworkSystem.Infastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression config);
    }
}