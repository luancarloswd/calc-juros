using AutoMapper;
using CalcTest.Domain.Model;
using CalcTest.Service.ViewModels;

namespace CalcTest.Service.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
            => CreateMap<JurosCompostos, JurosCompostosOutputViewModel>();
    }
}
