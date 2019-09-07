using AutoMapper;
using DesafioEcommerce.Application.ViewModels;
using DesafioEcommerce.Domain.Entities;

namespace DesafioEcommerce.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
        }
    }
}
