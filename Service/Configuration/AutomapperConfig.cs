using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Configuration
{
    public class AutomapperConfig
    {
        private static IMapper mapper;
        public static IMapper Mapper
        {
            get
            {
                return mapper ?? (mapper = new AutomapperConfig().ConfigureMapper());
            }
        }
        private AutomapperConfig()
        {
        }

        private IMapper ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ServiceModel.Product, Data.Entities.Product>().ReverseMap();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }

    }
}
