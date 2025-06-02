using AutoMapper;

namespace GreenMarket.Application.Common.Mappers
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
