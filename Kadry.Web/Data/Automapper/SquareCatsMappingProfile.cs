//using AutoMapper;
//using Db;
//using SqaureCats.Models.BusinessLogicViewModel;

//namespace Kadry.Web.Data.AutoMapper
//{

//    public class Source<T>
//    {
//        public T Value { get; set; }
//    }
//    public class Destination<T>
//    {
//        public T Value { get; set; }
//    }
//    public class SquareCatsMappingProfile : Profile
//    {


//        public SquareCatsMappingProfile()
//        {
//            CreateMap<CountryDb, BLCountryViewModel>().ReverseMap();
//            CreateMap<ContrahentDb, BLContrahentViewModel>().ForMember(dst=>dst.AddressCountryId, opt=>opt.MapFrom(src=>src.AddressCountryId));
//            CreateMap<BLContrahentViewModel, ContrahentDb>().ForMember(dst => dst.AddressCountryId, opt => opt.MapFrom(src => src.AddressCountryId));
//            CreateMap<InvoiceItemDb , BLInvoiceItemViewModel > ().ReverseMap();
//            CreateMap<InvoiceDb, BLInvoiceViewModel>().ReverseMap();
//            CreateMap<ProductDb, BLProductViewModel>().ReverseMap();
//            //CreateMap<MyEntity, BaseViewModel>().IncludeAllDerived().ReverseMap();
//            //CreateMap<IEnumerable<MyEntity>, IEnumerable<BaseViewModel>>().IncludeAllDerived().ReverseMap();
//            //CreateMap(typeof(Source<>), typeof(Destination<>));


//            //.ForMember(dst => dst.PartInteger, opt => opt.MapFrom(src => src.Integer));

//        }
//    }
//}