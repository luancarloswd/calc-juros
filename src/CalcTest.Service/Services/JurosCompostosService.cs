using AutoMapper;
using CalcTest.Crosscutting.Interfaces;
using CalcTest.Domain.Errors;
using CalcTest.Domain.Model;
using CalcTest.Service.Interfaces;
using CalcTest.Service.ViewModels;
using System;
using System.Threading.Tasks;

namespace CalcTest.Service.Services
{
    public class JurosCompostosService : IJurosCompostosService
    {
        private readonly IMapper _mapper;
        private readonly IDomainNotificationManager _domainNotificationManager;
        public JurosCompostosService(IMapper mapper,
            IDomainNotificationManager domainNotificationManager)
        {
            _mapper = mapper;
            _domainNotificationManager = domainNotificationManager;
        }
        public Task<JurosCompostosOutputViewModel> Calcular(JurosCompostosInputViewModel viewModel)
        {
            try
            {
                var jurosCompostos = _mapper.Map<JurosCompostos>(viewModel);

                if (jurosCompostos.Validar())
                    return Task.FromResult(_mapper.Map<JurosCompostosOutputViewModel>(jurosCompostos));

                _domainNotificationManager.Add("Valores", Errors.ValoresInvalidos);
            }
            catch (InvalidOperationException)
            {
                _domainNotificationManager.Add("Pârâmetros", Errors.ErroAoCalcularJurosCompostos);
            }
            catch (OverflowException)
            {
                _domainNotificationManager.Add("Pârâmetros", Errors.EstouroMemoriaServidorAoCalcular);
            }
            catch (AutoMapperMappingException ex) when (ex.GetBaseException() is OverflowException)
            {
                _domainNotificationManager.Add("Pârâmetros", Errors.EstouroMemoriaServidorAoCalcular);
            }
            catch (Exception)
            {
                _domainNotificationManager.Add("Pârâmetros", Errors.ErroAoCalcularJurosCompostos);

            }

            return Task.FromResult<JurosCompostosOutputViewModel>(null);
        }
    }
}
