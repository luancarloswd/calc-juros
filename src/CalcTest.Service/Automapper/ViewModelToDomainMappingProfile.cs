using AutoMapper;
using CalcTest.Domain.Model;
using CalcTest.Service.ViewModels;

namespace CalcTest.Service.Automapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<JurosCompostosInputViewModel, JurosCompostos>()
                .ConstructUsing(jcvm => new JurosCompostos(jcvm.ValorInicial, jcvm.Meses));
        }
    }
}
