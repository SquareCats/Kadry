using AutoMapper;
using Kadry.Db;
using Kadry.Db.Data;
using Kadry.Web.Models;
using Kadry.Web.Models.BusinessLogicViewModel;
using Kadry.Web.Models.Dictionaries;

namespace Kadry.Web.Data.AutoMapper
{

    public class Source<T>
    {
        public T Value { get; set; }
    }
    public class Destination<T>
    {
        public T Value { get; set; }
    }
    public class KadryMappingProfile : Profile
    {


        public KadryMappingProfile()
        {
            CreateMap<AppUser, AppUserViewModel>().ReverseMap();
            CreateMap<DictionaryDb, DictionaryBaseViewModel>().ReverseMap();
            CreateMap<CountryDb, CountryViewModel>().ReverseMap();
            CreateMap<PersonDb, PersonViewModel>().ReverseMap();
            //     AutoMapper.Mapper.CreateMap<ReferenceEngine, Engine>()
            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description)).ReverseMap();

        }
    }
}