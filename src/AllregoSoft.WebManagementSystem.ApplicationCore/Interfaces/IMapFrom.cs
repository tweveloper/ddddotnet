using AutoMapper;

namespace AllregoSoft.WebManagementSystem.ApplicationCore.Interfaces
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
