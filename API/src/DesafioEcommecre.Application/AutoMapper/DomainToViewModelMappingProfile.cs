using AutoMapper;
using DesafioEcommerce.Application.ViewModels;
using DesafioEcommerce.Domain.Entities;

namespace DesafioEcommerce.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
