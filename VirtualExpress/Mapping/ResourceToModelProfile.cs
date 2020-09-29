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
            CreateMap<SaveCityResource, City>();
            CreateMap<SaveCommentaryResource, Comentary>();
            CreateMap<SaveFreightResource, Freight>();
            CreateMap<SavePackageResource, Package>();
            CreateMap<SavePayResource, Pay>();
            CreateMap<SaveSubscriptionResource, Subscription>();
            CreateMap<SaveTerminalResource, Terminal>();
            CreateMap<SaveChatResource, Chat>();
            CreateMap<SaveCustomerResource, Customer>();
            CreateMap<SaveCustomerServiceEmployeeResource, CustomerServiceEmployee>();
            CreateMap<SaveDispatcherResource, Dispatcher>();
            CreateMap<SaveDriverResource, Driver>();
        }
    }
}
