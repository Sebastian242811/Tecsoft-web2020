using AutoMapper;
using VirtualExpress.Domain.Models;
using VirtualExpress.Resource;

namespace VirtualExpress.Mapping
{
    public class ModelToResourceToProfile : Profile
    {
        public ModelToResourceToProfile()
        {
            CreateMap<Company, CompanyResource>();
        }
    }
}
