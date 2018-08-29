using AutoMapper;

namespace AviTrackr.Domain.Base.Services
{
    public class MapperWrapper : IMapperWrapper
    {
        public TDestination Map<TSource, TDestination>(TSource to)
        {
            return Mapper.Map<TSource, TDestination>(to);
        }
    }
}