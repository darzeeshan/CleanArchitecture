using AutoMapper;
using Cone.InventoryManagement.Web.Models.Clients;
using Cone.InventoryManagement.Web.Services.Base;

namespace Cone.InventoryManagement.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Client setup
            CreateMap<ClientSetupDetailedDto, ClientSetupDetailedVM>().ReverseMap();
            CreateMap<ClientSetupDetailedDto, ClientSetupEditVM>().ReverseMap();
            CreateMap<BaseClientSetupDto, BaseClientSetupVM>().ReverseMap();
            CreateMap<ClientSetupEditDto, ClientSetupEditVM>().ReverseMap();

            //Client connection
            CreateMap<ClientConnectionForSpecificSetupDto, ClientConnectionForSpecificSetupVM>().ReverseMap();
            CreateMap<BaseClientConnectionDto, BaseClientConnectionVM>().ReverseMap();
            CreateMap<ClientConnectionEditDto, ClientConnectionEditVM>().ReverseMap();
            CreateMap<ClientConnectionDetailedDto, ClientConnectionEditVM>().ReverseMap();

            CreateMap<BaseCommandResponse, Response<int>>();
        }
    }
}
