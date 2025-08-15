using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.Identity.Client;

namespace Mango.Services.CouponAPI
{
    public class MappingConfig
    {
        private readonly ILogger<MappingConfig> _logger;

        public MappingConfig(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MappingConfig>();
        }

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
         
            return mappingConfig;
        }
    }
}
