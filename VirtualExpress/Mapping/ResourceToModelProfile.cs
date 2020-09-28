using AutoMapper;
using VirtualExpress.Domain.Models;
using VirtualExpress.Resource;

namespace VirtualExpress.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCompanyResource, Company>();
        }
    }
}
