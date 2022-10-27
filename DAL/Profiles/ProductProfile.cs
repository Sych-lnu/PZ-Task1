using AutoMapper;
using DTO;

namespace DAL.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<product, ProductDTO>().ReverseMap();
        }
    }
}
