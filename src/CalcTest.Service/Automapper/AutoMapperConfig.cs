using System;
using System.Collections.Generic;
using System.Text;

namespace CalcTest.Service.Automapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
         => new MapperConfiguration(cfg =>
         {
             cfg.AddProfile(new ViewModelToDomainMappingProfile());
             cfg.AddProfile(new DomainToViewModelMappingProfile());
         });
    }
}
