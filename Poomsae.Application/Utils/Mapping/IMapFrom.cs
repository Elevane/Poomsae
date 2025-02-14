using AutoMapper;

namespace Poomsae.Application.Utils.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
    }
}
