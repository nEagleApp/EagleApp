using AutoMapper;

namespace Eagle.Core.AutoMapper
{
    public static class MapperExtension
    {
        public static void Map(
            this IMapper mapper,
            object destination,
            params object[] sources)
        {
            foreach (var source in sources)
            {
                mapper.Map(source, destination);
            }
        }

        public static TDestination Map<TDestination>(
            this IMapper mapper,
            params object[] sources)
            where TDestination : class, new()
        {
            var destination = new TDestination();
            Map(mapper, destination, sources);

            return destination;
        }
    }

}
