using AutoMapper;
using DemoNop.Core.Domain.Entities;
using DemoNop.Core.Infrastructure.Mapper;
using DemoNop.Web.Models;

namespace DemoNop.Web.Infrastructure.AutoMapper
{
    public class DemoNopMapperConfiguration : Profile, IOrderedMapperProfile
    {

        #region Ctor
        public DemoNopMapperConfiguration()
        {
            //create specific maps
            CreateConfigMaps();
        }
        #endregion Ctor

        #region Utilities
        /// <summary>
        /// Create catalog maps 
        /// </summary>
        protected virtual void CreateConfigMaps() 
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();

            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();

            CreateMap<UserInfo, UserInfoModel>();
            CreateMap<UserInfoModel, UserInfo>();
        }
        #endregion Utilities

        #region Properties

        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order => 0;

        #endregion
    }
}
