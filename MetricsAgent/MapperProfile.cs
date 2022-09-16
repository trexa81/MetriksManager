﻿using AutoMapper;
using MetricsAgent.Models.Dto;
using MetricsAgent.Models.Requests;
using MetricsAgent.Models;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<CpuMetricCreateRequest, CpuMetric>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(x => x.Time, opt => opt.MapFrom(src => (int)src.Time.TotalSeconds));

            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<HddMetricCreateRequest, HddMetric>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(x => x.Time, opt => opt.MapFrom(src => (int)src.Time.TotalSeconds));

            CreateMap<NetworkMetric, NetworkMetricDto>();
            CreateMap<NetworkMetricCreateRequest, NetworkMetric>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(x => x.Time, opt => opt.MapFrom(src => (int)src.Time.TotalSeconds));

            CreateMap<RamMetric, RamMetricDto>();
            CreateMap<NetworkMetricCreateRequest, NetworkMetric>()
                .ForMember(x => x.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(x => x.Time, opt => opt.MapFrom(src => (int)src.Time.TotalSeconds));
        }
    }
}