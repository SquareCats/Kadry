using AutoMapper;
using Kadry.Db;
using Kadry.Web.Models.BusinessLogicViewModel;

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
            CreateMap<CountryDb, CountryViewModel>().ReverseMap();
           
        }
    }
}