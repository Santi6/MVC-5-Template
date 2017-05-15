using AutoMapper;

namespace SocialNetworkSystem.Web.Infastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression config);
    }
}