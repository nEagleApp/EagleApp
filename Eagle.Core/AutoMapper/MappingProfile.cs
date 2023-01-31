using AutoMapper;
using Eagle.Core.Helpers;
using System.Reflection;

namespace Eagle.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var assemblies = AssemblyHelper.GetAllExecutingAssemblies();
            ApplyMappingsFromAssembly(assemblies);
        }
        public MappingProfile(params Assembly[] assemblies)
        {
            ApplyMappingsFromAssembly(assemblies);
        }

        private void ApplyMappingsFromAssembly(params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetExportedTypes()
                    .Where(t => t.GetInterfaces().Any(i =>
                        i.IsGenericType
                            && i.GetGenericTypeDefinition() == typeof(IBidirectionalMap<>)))
                    .ToList();

                foreach (var type in types)
                {
                    var instance = Activator.CreateInstance(type);
                    var interfaces = type
                        .GetInterfaces()
                        .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBidirectionalMap<>));

                    foreach (var i in interfaces)
                    {
                        i.GetMethod("CreateMap")?
                            .Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }

}
