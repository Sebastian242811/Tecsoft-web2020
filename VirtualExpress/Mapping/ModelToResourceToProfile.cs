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
            CreateMap<City, CityResource>();
            CreateMap<Comentary, CommentaryResource>();
            CreateMap<Freight, FreightResource>();
            CreateMap<Package, PackageResource>();
            CreateMap<Pay, PayResource>();
            CreateMap<Subscription, SubscriptionResource>();
            CreateMap<Terminal, TerminalResource>();
            CreateMap<Chat, ChatResource>();
            CreateMap<Customer, CustomerResource>();
            CreateMap<CustomerServiceEmployee, CustomerServiceEmployeeResource>();
            CreateMap<Dispatcher, DispatcherResource>();
            CreateMap<Driver, DriverResource>();
        }
    }
}
