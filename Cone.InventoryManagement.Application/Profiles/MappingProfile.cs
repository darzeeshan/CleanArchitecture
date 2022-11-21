using AutoMapper;
using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Domain.Entities;

namespace Cone.InventoryManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Connection DTO
            //Connecting child tables with thier DTOs
            CreateMap<tblMapClientConnection, ClientConnectionDetailedDto>()
                .ForMember(
                    dest => dest.ConnectionId, opt => opt.MapFrom(src => src.intClientConnectionId))
                .ForMember(
                    dest => dest.SetupId,opt => opt.MapFrom(src => src.intClientSetupId))
                .ForMember(
                    dest => dest.ConnectionType, opt => opt.MapFrom(src => src.bytConnectionType))
                .ForMember(
                    dest => dest.Key, opt => opt.MapFrom(src => src.txtKey))
                .ForMember(
                    dest => dest.Username, opt => opt.MapFrom(src => src.txtUsername))
                .ForMember(
                    dest => dest.Password, opt => opt.MapFrom(src => src.txtPassword))
                .ForMember(
                    dest => dest.Port, opt => opt.MapFrom(src => src.txtPort))
                .ForMember(
                    dest => dest.DateTime, opt => opt.MapFrom(src => src.dtDateTime))
                .ForMember(
                    dest => dest.LastUpdated, opt => opt.MapFrom(src => src.dtLastUpdated))
                .ReverseMap();

            CreateMap<tblMapClientConnection, BaseClientConnectionDto>()
                .ForMember(
                    dest => dest.SetupId, opt => opt.MapFrom(src => src.intClientSetupId))
                .ForMember(
                    dest => dest.ConnectionType, opt => opt.MapFrom(src => src.bytConnectionType))
                .ForMember(
                    dest => dest.Key, opt => opt.MapFrom(src => src.txtKey))
                .ForMember(
                    dest => dest.Username, opt => opt.MapFrom(src => src.txtUsername))
                .ForMember(
                    dest => dest.Password, opt => opt.MapFrom(src => src.txtPassword))
                .ForMember(
                    dest => dest.Port, opt => opt.MapFrom(src => src.txtPort))
                .ReverseMap();

            CreateMap<tblMapClientConnection, ClientConnectionEditDto>()
                .ForMember(
                    dest => dest.SetupId, opt => opt.MapFrom(src => src.intClientSetupId))
                .ForMember(
                    dest => dest.ConnectionType, opt => opt.MapFrom(src => src.bytConnectionType))
                .ForMember(
                    dest => dest.Key, opt => opt.MapFrom(src => src.txtKey))
                .ForMember(
                    dest => dest.Username, opt => opt.MapFrom(src => src.txtUsername))
                .ForMember(
                    dest => dest.Password, opt => opt.MapFrom(src => src.txtPassword))
                .ForMember(
                    dest => dest.Port, opt => opt.MapFrom(src => src.txtPort))
                .ForMember(
                    dest => dest.LastUpdated, opt => opt.MapFrom(src => src.dtLastUpdated))
                .ReverseMap();
            #endregion

            #region Setup DTO
            CreateMap<tblMapClientSetup, ClientSetupDetailedDto>()
                .ForMember(
                    dest => dest.SetupId, opt => opt.MapFrom(src => src.intClientSetupId))
                .ForMember(
                    dest => dest.Status, opt => opt.MapFrom(src => src.bytStatus))
                .ForMember(
                    dest => dest.ClientName, opt => opt.MapFrom(src => src.txtClientName))
                .ForMember(
                    dest => dest.ClientId, opt => opt.MapFrom(src => src.txtClientId))
                .ForMember(
                    dest => dest.FolderLocation, opt => opt.MapFrom(src => src.txtFolderLocation))
                .ForMember(
                    dest => dest.DateTime, opt => opt.MapFrom(src => src.dtDateTime))
                .ReverseMap();

            CreateMap<tblMapClientSetup, BaseClientSetupDto>()
               .ForMember(
                   dest => dest.Status, opt => opt.MapFrom(src => src.bytStatus))
               .ForMember(
                   dest => dest.ClientName, opt => opt.MapFrom(src => src.txtClientName))
               .ForMember(
                   dest => dest.ClientId, opt => opt.MapFrom(src => src.txtClientId))
               .ForMember(
                   dest => dest.FolderLocation, opt => opt.MapFrom(src => src.txtFolderLocation))
               .ReverseMap();

            CreateMap<tblMapClientSetup, ClientSetupStatusChangeDto>()
               .ForMember(
                   dest => dest.Status, opt => opt.MapFrom(src => src.bytStatus))
               .ReverseMap();
            #endregion

            //.AfterMap((s, d, ClientSetupDto) => ClientSetupDto.Mapper.Map(s, d))
            //.ReverseMap();

            //CreateMap<tblMapClientSetup, ClientSetupDto>()
            //    .ReverseMap();


            //Connecting parent table with it's child table
            //CreateMap<tblMapClientSetup, ClientSetupDto>()
            //    .ReverseMap()
            //    .ForMember(q => q.mapClientFiles, q => q.Ignore())
            //    .ForMember(q => q.mapClientConnections, q => q.Ignore());


            //stackoverflow.com/questions/8944577/automapper-map-child-property-that-also-has-a-map-defined
            //Change correct parent child above


            //stackoverflow.com/questions/21413273/automapper-convert-from-multiple-sources
            //Map multiple sources - Use when columns in multiple DTOs is similar
        }
    }


}
