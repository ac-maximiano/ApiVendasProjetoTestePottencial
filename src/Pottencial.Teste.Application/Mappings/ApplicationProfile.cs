using AutoMapper;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Domain.Entities;

namespace Pottencial.Teste.Application.Mappings
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Venda, VendaDto>().ReverseMap();
            CreateMap<Vendedor, VendedorDto>().ReverseMap();
            CreateMap<Produto, ProdutoDto>().ReverseMap();
            CreateMap<ItemVenda, ItemVendaDto>().ReverseMap();
        }
    }
}
