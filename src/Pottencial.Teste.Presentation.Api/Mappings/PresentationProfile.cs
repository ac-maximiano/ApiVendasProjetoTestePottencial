using AutoMapper;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Presentation.Api.ViewModels;

namespace Pottencial.Teste.Presentation.Api.Mappings
{
    public class PresentationProfile : Profile
    {
        public PresentationProfile()
        {
            CreateMap<VendaDto, VendaQueryVM>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.VendedorNome, opt => opt.MapFrom(src => src.Vendedor.Nome));
            CreateMap<VendaDto, VendaCommandVM>().ReverseMap();
            CreateMap<ItemVendaDto, ItemVendaVM>().ReverseMap();
            CreateMap<ProdutoDto, ProdutoVM>().ReverseMap();
            CreateMap<VendedorDto, VendedorVM>().ReverseMap();
        }
    }
}
